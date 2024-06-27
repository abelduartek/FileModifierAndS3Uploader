using Amazon;
using FileModifierAndS3Uploader.Utils;
using FileModifierAndS3Uploader.S3;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly FileManager _fileManager;
        private readonly TextReplacer _textReplacer;
        private S3UploaderService _s3Uploader;

        public Form1()
        {
            InitializeComponent();
            _fileManager = new FileManager();
            _textReplacer = new TextReplacer();

            btnSearch.Click += BtnSearch_Click;
            btnValidateFiles.Click += BtnValidateFiles_Click;
            btnFindReplace.Click += BtnFindReplace_Click;
            btnSendS3.Click += BtnSendS3_Click;

            gbFindAndReplace.Enabled = false;
            gbSendS3.Enabled = false;
            treeView.AfterSelect += TreeView_AfterSelect;
            cbAmazonRegion.DataSource = RegionEndpoint.EnumerableAllRegions.Select(region => region.SystemName).ToList();

            _fileManager.ProgressChanged += UpdateProgressBar;
            _textReplacer.ProgressChanged += UpdateProgressBar;
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            gbFindAndReplace.Enabled = treeView.SelectedNode != null;
            gbSendS3.Enabled = treeView.SelectedNode != null;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void BtnValidateFiles_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            string[] searchTexts = txtTextSearch.Text.Split(';').Select(t => t.Trim()).ToArray();
            _fileManager.LoadDirectory(treeView, path, searchTexts, progressBar);

            gbFindAndReplace.Enabled = treeView.Nodes.Count > 0;
            gbSendS3.Enabled = treeView.Nodes.Count > 0;
        }

        private void BtnFindReplace_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchReplace.Text;
            string replaceText = txtTextReplace.Text;

            if (string.IsNullOrWhiteSpace(searchText) || string.IsNullOrWhiteSpace(replaceText))
            {
                MessageBox.Show(this, "Os campos de texto para substituir e texto novo não podem estar vazios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (treeView.SelectedNode == null)
            {
                MessageBox.Show(this, "Por favor, selecione um nó no TreeView.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(this, $"Você selecionou o nó '{treeView.SelectedNode.Text}'. Deseja substituir o texto nos arquivos desse nó e seus filhos?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            _textReplacer.ReplaceTextInFiles(treeView.SelectedNode, searchText, replaceText, progressBar);
            MessageBox.Show(this, "Substituição concluída com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BtnSendS3_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;

            if (treeView.SelectedNode == null)
            {
                MessageBox.Show(this, "Por favor, selecione um nó no TreeView.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string bucketName = textBox2.Text;
            string region = cbAmazonRegion.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(bucketName) || string.IsNullOrWhiteSpace(region))
            {
                MessageBox.Show(this, "Os campos de Bucket S3 e Region S3 não podem estar vazios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _s3Uploader = new S3UploaderService(region);
                await _s3Uploader.UploadFilesAsync(treeView.SelectedNode, bucketName, path, progressBar);
                MessageBox.Show(this, "Arquivos enviados para o S3 com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Erro ao enviar arquivos para o S3: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProgressBar(int value, int maximum)
        {
            progressBar.Maximum = maximum;
            progressBar.Value = value;
            Application.DoEvents();
        }
    }
}