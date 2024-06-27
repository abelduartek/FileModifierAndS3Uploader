using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileModifierAndS3Uploader.Utils
{
    public class FileManager
    {
        public event Action<int, int> ProgressChanged;

        public void LoadDirectory(TreeView treeView, string path, string[] searchTexts, ProgressBar progressBar)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show("O caminho especificado não existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            treeView.Nodes.Clear();
            progressBar.Value = 0;
            int fileCount = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
            progressBar.Maximum = fileCount;

            LoadDirectoryNodes(path, searchTexts, treeView.Nodes, progressBar);
        }

        private void LoadDirectoryNodes(string dir, string[] searchTexts, TreeNodeCollection nodeCollection, ProgressBar progressBar)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            TreeNode directoryNode = new TreeNode(di.Name) { Tag = di };
            bool directoryContainsText = false;

            foreach (var subDir in di.GetDirectories())
            {
                TreeNode subDirNode = LoadDirectoryNodes(subDir.FullName, searchTexts, progressBar);
                if (subDirNode != null)
                {
                    directoryContainsText = true;
                    directoryNode.Nodes.Add(subDirNode);
                }
            }

            foreach (var file in di.GetFiles())
            {
                bool containsText = CheckFileForText(file, searchTexts);
                if (containsText)
                {
                    directoryContainsText = true;
                    TreeNode fileNode = new TreeNode(file.Name) { Tag = file };
                    directoryNode.Nodes.Add(fileNode);
                }

                progressBar.Value += 1;
                Application.DoEvents();
                ProgressChanged?.Invoke(progressBar.Value, progressBar.Maximum);
            }

            if (directoryContainsText || directoryNode.Nodes.Count > 0)
            {
                nodeCollection.Add(directoryNode);
            }
        }

        private TreeNode LoadDirectoryNodes(string dir, string[] searchTexts, ProgressBar progressBar)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            TreeNode directoryNode = new TreeNode(di.Name) { Tag = di };
            bool directoryContainsText = false;

            foreach (var subDir in di.GetDirectories())
            {
                TreeNode subDirNode = LoadDirectoryNodes(subDir.FullName, searchTexts, progressBar);
                if (subDirNode != null)
                {
                    directoryContainsText = true;
                    directoryNode.Nodes.Add(subDirNode);
                }
            }

            foreach (var file in di.GetFiles())
            {
                bool containsText = CheckFileForText(file, searchTexts);
                if (containsText)
                {
                    directoryContainsText = true;
                    TreeNode fileNode = new TreeNode(file.Name) { Tag = file };
                    directoryNode.Nodes.Add(fileNode);
                }

                progressBar.Value += 1;
                Application.DoEvents();
                ProgressChanged?.Invoke(progressBar.Value, progressBar.Maximum);
            }

            return directoryContainsText || directoryNode.Nodes.Count > 0 ? directoryNode : null;
        }

        private bool CheckFileForText(FileInfo file, string[] searchTexts)
        {
            try
            {
                string fileContent = File.ReadAllText(file.FullName);
                return searchTexts.Any(text => fileContent.Contains(text));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao ler o arquivo {file.FullName}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
