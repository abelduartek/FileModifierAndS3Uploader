using System;
using System.IO;
using System.Windows.Forms;

namespace FileModifierAndS3Uploader.Utils
{
    public class TextReplacer
    {
        public event Action<int, int> ProgressChanged;

        public void ReplaceTextInFiles(TreeNode node, string searchText, string replaceText, ProgressBar progressBar)
        {
            progressBar.Value = 0;
            int fileCount = CountFiles(node);
            progressBar.Maximum = fileCount;

            PerformTextReplacement(node, searchText, replaceText, progressBar);
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

        private void PerformTextReplacement(TreeNode node, string searchText, string replaceText, ProgressBar progressBar)
        {
            if (node.Tag is FileInfo file)
            {
                try
                {
                    string fileContent = File.ReadAllText(file.FullName);
                    if (fileContent.Contains(searchText))
                    {
                        fileContent = fileContent.Replace(searchText, replaceText);
                        File.WriteAllText(file.FullName, fileContent);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar o arquivo {file.FullName}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                progressBar.Value += 1;
                Application.DoEvents();
                ProgressChanged?.Invoke(progressBar.Value, progressBar.Maximum);
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                PerformTextReplacement(childNode, searchText, replaceText, progressBar);
            }
        }
    }
}
