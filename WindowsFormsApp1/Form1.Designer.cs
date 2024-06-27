namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTextSearch = new System.Windows.Forms.TextBox();
            this.btnValidateFiles = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchReplace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTextReplace = new System.Windows.Forms.TextBox();
            this.btnFindReplace = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbFindAndReplace = new System.Windows.Forms.GroupBox();
            this.gbSendS3 = new System.Windows.Forms.GroupBox();
            this.cbAmazonRegion = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSendS3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbFindAndReplace.SuspendLayout();
            this.gbSendS3.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(377, 575);
            this.treeView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Caminho da Pasta:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(418, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Procurar";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Textos (separados por;) :";
            // 
            // txtTextSearch
            // 
            this.txtTextSearch.Location = new System.Drawing.Point(137, 75);
            this.txtTextSearch.Name = "txtTextSearch";
            this.txtTextSearch.Size = new System.Drawing.Size(275, 20);
            this.txtTextSearch.TabIndex = 5;
            // 
            // btnValidateFiles
            // 
            this.btnValidateFiles.Location = new System.Drawing.Point(137, 112);
            this.btnValidateFiles.Name = "btnValidateFiles";
            this.btnValidateFiles.Size = new System.Drawing.Size(275, 23);
            this.btnValidateFiles.TabIndex = 6;
            this.btnValidateFiles.Text = "Procurar";
            this.btnValidateFiles.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(415, 564);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(483, 23);
            this.progressBar.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Texto à Substituir:";
            // 
            // txtSearchReplace
            // 
            this.txtSearchReplace.Location = new System.Drawing.Point(136, 24);
            this.txtSearchReplace.Name = "txtSearchReplace";
            this.txtSearchReplace.Size = new System.Drawing.Size(275, 20);
            this.txtSearchReplace.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Texto Novo:";
            // 
            // txtTextReplace
            // 
            this.txtTextReplace.Location = new System.Drawing.Point(136, 62);
            this.txtTextReplace.Name = "txtTextReplace";
            this.txtTextReplace.Size = new System.Drawing.Size(275, 20);
            this.txtTextReplace.TabIndex = 11;
            // 
            // btnFindReplace
            // 
            this.btnFindReplace.Location = new System.Drawing.Point(136, 106);
            this.btnFindReplace.Name = "btnFindReplace";
            this.btnFindReplace.Size = new System.Drawing.Size(122, 23);
            this.btnFindReplace.TabIndex = 12;
            this.btnFindReplace.Text = "Procurar e Substituir";
            this.btnFindReplace.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 545);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Progresso:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTextSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnValidateFiles);
            this.groupBox1.Location = new System.Drawing.Point(395, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 152);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carregar Estrutura";
            // 
            // gbFindAndReplace
            // 
            this.gbFindAndReplace.Controls.Add(this.txtSearchReplace);
            this.gbFindAndReplace.Controls.Add(this.label3);
            this.gbFindAndReplace.Controls.Add(this.label4);
            this.gbFindAndReplace.Controls.Add(this.btnFindReplace);
            this.gbFindAndReplace.Controls.Add(this.txtTextReplace);
            this.gbFindAndReplace.Location = new System.Drawing.Point(396, 171);
            this.gbFindAndReplace.Name = "gbFindAndReplace";
            this.gbFindAndReplace.Size = new System.Drawing.Size(539, 150);
            this.gbFindAndReplace.TabIndex = 15;
            this.gbFindAndReplace.TabStop = false;
            this.gbFindAndReplace.Text = "Encontrar e Substituir";
            // 
            // gbSendS3
            // 
            this.gbSendS3.Controls.Add(this.cbAmazonRegion);
            this.gbSendS3.Controls.Add(this.textBox2);
            this.gbSendS3.Controls.Add(this.label6);
            this.gbSendS3.Controls.Add(this.label7);
            this.gbSendS3.Controls.Add(this.btnSendS3);
            this.gbSendS3.Location = new System.Drawing.Point(396, 327);
            this.gbSendS3.Name = "gbSendS3";
            this.gbSendS3.Size = new System.Drawing.Size(539, 150);
            this.gbSendS3.TabIndex = 16;
            this.gbSendS3.TabStop = false;
            this.gbSendS3.Text = "Enviar para S3";
            // 
            // cbAmazonRegion
            // 
            this.cbAmazonRegion.FormattingEnabled = true;
            this.cbAmazonRegion.Location = new System.Drawing.Point(136, 66);
            this.cbAmazonRegion.Name = "cbAmazonRegion";
            this.cbAmazonRegion.Size = new System.Drawing.Size(275, 21);
            this.cbAmazonRegion.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(136, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(275, 20);
            this.textBox2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Bucket S3:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Region S3:";
            // 
            // btnSendS3
            // 
            this.btnSendS3.Location = new System.Drawing.Point(136, 106);
            this.btnSendS3.Name = "btnSendS3";
            this.btnSendS3.Size = new System.Drawing.Size(122, 23);
            this.btnSendS3.TabIndex = 12;
            this.btnSendS3.Text = "Enviar para S3";
            this.btnSendS3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 599);
            this.Controls.Add(this.gbSendS3);
            this.Controls.Add(this.gbFindAndReplace);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.treeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FileModifierAndS3Uploader";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFindAndReplace.ResumeLayout(false);
            this.gbFindAndReplace.PerformLayout();
            this.gbSendS3.ResumeLayout(false);
            this.gbSendS3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTextSearch;
        private System.Windows.Forms.Button btnValidateFiles;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchReplace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTextReplace;
        private System.Windows.Forms.Button btnFindReplace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbFindAndReplace;
        private System.Windows.Forms.GroupBox gbSendS3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSendS3;
        private System.Windows.Forms.ComboBox cbAmazonRegion;
    }
}