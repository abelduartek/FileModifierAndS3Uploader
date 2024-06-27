using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace FileModifierAndS3Uploader.S3
{
    public class S3UploaderService
    {
        private readonly AmazonS3Client _s3Client;
        private readonly TransferUtility _transferUtility;

        public S3UploaderService(string region)
        {
            _s3Client = new AmazonS3Client(Amazon.RegionEndpoint.GetBySystemName(region));
            _transferUtility = new TransferUtility(_s3Client);
        }

        public async Task UploadFilesAsync(TreeNode node, string bucketName, string localBasePath, ProgressBar progressBar)
        {
            progressBar.Value = 0;
            int fileCount = CountFiles(node);
            progressBar.Maximum = fileCount;

            await UploadFilesToS3(node, bucketName, localBasePath, progressBar);
        }

        private async Task UploadFilesToS3(TreeNode node, string bucketName, string localBasePath, ProgressBar progressBar)
        {
            if (node.Tag is FileInfo file)
            {
                try
                {
                    string relativePath = GetRelativePath(localBasePath, file.FullName).Replace(Path.DirectorySeparatorChar, '/');
                    var request = new TransferUtilityUploadRequest
                    {
                        FilePath = file.FullName,
                        BucketName = bucketName,
                        Key = relativePath
                    };
                    await _transferUtility.UploadAsync(request);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao enviar o arquivo {file.FullName} para o S3: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                progressBar.Value += 1;
                Application.DoEvents();
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                await UploadFilesToS3(childNode, bucketName, localBasePath, progressBar);
            }
        }

        private int CountFiles(TreeNode node)
        {
            int count = 0;
            if (node.Tag is FileInfo)
            {
                count++;
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                count += CountFiles(childNode);
            }

            return count;
        }

        private string GetRelativePath(string basePath, string fullPath)
        {
            if (fullPath.StartsWith(basePath))
            {
                return fullPath.Substring(basePath.Length).TrimStart(Path.DirectorySeparatorChar);
            }
            throw new ArgumentException("O caminho completo não está dentro do caminho base.");
        }
    }
}
