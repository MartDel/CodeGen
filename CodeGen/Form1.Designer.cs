namespace CodeGen
{
    partial class Home
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ListUpdate = new System.Windows.Forms.FlowLayoutPanel();
            this.NoTagLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NameTxtBox = new System.Windows.Forms.TextBox();
            this.DescriptionTxtBox = new System.Windows.Forms.TextBox();
            this.TechnoTxtBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FolderTxtBox = new System.Windows.Forms.TextBox();
            this.FolderBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.RemoteTxtBox = new System.Windows.Forms.TextBox();
            this.ValidateBtn = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.LoadingGif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1282, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(336, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 524);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 34);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dernières MAJ :";
            // 
            // ListUpdate
            // 
            this.ListUpdate.AutoScroll = true;
            this.ListUpdate.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ListUpdate.Location = new System.Drawing.Point(21, 195);
            this.ListUpdate.Name = "ListUpdate";
            this.ListUpdate.Size = new System.Drawing.Size(309, 507);
            this.ListUpdate.TabIndex = 6;
            this.ListUpdate.WrapContents = false;
            // 
            // NoTagLabel
            // 
            this.NoTagLabel.AutoSize = true;
            this.NoTagLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.NoTagLabel.Location = new System.Drawing.Point(17, 203);
            this.NoTagLabel.Name = "NoTagLabel";
            this.NoTagLabel.Size = new System.Drawing.Size(277, 19);
            this.NoTagLabel.TabIndex = 7;
            this.NoTagLabel.Text = "Il n\'y a pas de tag pour l\'instant...";
            this.NoTagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NoTagLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(612, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 47);
            this.label1.TabIndex = 8;
            this.label1.Text = "Quel projet créer ?";
            // 
            // NameTxtBox
            // 
            this.NameTxtBox.Location = new System.Drawing.Point(734, 247);
            this.NameTxtBox.Name = "NameTxtBox";
            this.NameTxtBox.Size = new System.Drawing.Size(215, 22);
            this.NameTxtBox.TabIndex = 9;
            // 
            // DescriptionTxtBox
            // 
            this.DescriptionTxtBox.Location = new System.Drawing.Point(734, 275);
            this.DescriptionTxtBox.Multiline = true;
            this.DescriptionTxtBox.Name = "DescriptionTxtBox";
            this.DescriptionTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionTxtBox.Size = new System.Drawing.Size(363, 129);
            this.DescriptionTxtBox.TabIndex = 10;
            // 
            // TechnoTxtBox
            // 
            this.TechnoTxtBox.FormattingEnabled = true;
            this.TechnoTxtBox.Items.AddRange(new object[] {
            "Arduino"});
            this.TechnoTxtBox.Location = new System.Drawing.Point(734, 410);
            this.TechnoTxtBox.Name = "TechnoTxtBox";
            this.TechnoTxtBox.Size = new System.Drawing.Size(121, 24);
            this.TechnoTxtBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(655, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nom :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(591, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Description :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(580, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Technologie :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(562, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Emplacement :";
            // 
            // FolderTxtBox
            // 
            this.FolderTxtBox.Location = new System.Drawing.Point(734, 480);
            this.FolderTxtBox.Name = "FolderTxtBox";
            this.FolderTxtBox.Size = new System.Drawing.Size(363, 22);
            this.FolderTxtBox.TabIndex = 15;
            // 
            // FolderBtn
            // 
            this.FolderBtn.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderBtn.ForeColor = System.Drawing.Color.Black;
            this.FolderBtn.Location = new System.Drawing.Point(734, 441);
            this.FolderBtn.Name = "FolderBtn";
            this.FolderBtn.Size = new System.Drawing.Size(121, 33);
            this.FolderBtn.TabIndex = 17;
            this.FolderBtn.Text = "Parcourir";
            this.FolderBtn.UseVisualStyleBackColor = true;
            this.FolderBtn.Click += new System.EventHandler(this.FolderBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12.2F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(537, 505);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "(Lien du remote) :";
            // 
            // RemoteTxtBox
            // 
            this.RemoteTxtBox.Location = new System.Drawing.Point(734, 508);
            this.RemoteTxtBox.Name = "RemoteTxtBox";
            this.RemoteTxtBox.Size = new System.Drawing.Size(363, 22);
            this.RemoteTxtBox.TabIndex = 18;
            // 
            // ValidateBtn
            // 
            this.ValidateBtn.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.ValidateBtn.ForeColor = System.Drawing.Color.Black;
            this.ValidateBtn.Location = new System.Drawing.Point(620, 577);
            this.ValidateBtn.Name = "ValidateBtn";
            this.ValidateBtn.Size = new System.Drawing.Size(382, 45);
            this.ValidateBtn.TabIndex = 20;
            this.ValidateBtn.Text = "Créer le dossier";
            this.ValidateBtn.UseVisualStyleBackColor = true;
            this.ValidateBtn.Click += new System.EventHandler(this.ValidateBtn_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.ErrorLabel.Location = new System.Drawing.Point(123, 230);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(69, 19);
            this.ErrorLabel.TabIndex = 21;
            this.ErrorLabel.Text = "Erreur...";
            this.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorLabel.Visible = false;
            // 
            // LoadingGif
            // 
            this.LoadingGif.Image = global::CodeGen.Properties.Resources.LoadingGif;
            this.LoadingGif.Location = new System.Drawing.Point(706, 546);
            this.LoadingGif.Name = "LoadingGif";
            this.LoadingGif.Size = new System.Drawing.Size(183, 186);
            this.LoadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingGif.TabIndex = 22;
            this.LoadingGif.TabStop = false;
            this.LoadingGif.Visible = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.ValidateBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RemoteTxtBox);
            this.Controls.Add(this.FolderBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FolderTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TechnoTxtBox);
            this.Controls.Add(this.DescriptionTxtBox);
            this.Controls.Add(this.NameTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NoTagLabel);
            this.Controls.Add(this.ListUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoadingGif);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeGen | Accueil";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel ListUpdate;
        private System.Windows.Forms.Label NoTagLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTxtBox;
        private System.Windows.Forms.TextBox DescriptionTxtBox;
        private System.Windows.Forms.ComboBox TechnoTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FolderTxtBox;
        private System.Windows.Forms.Button FolderBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox RemoteTxtBox;
        private System.Windows.Forms.Button ValidateBtn;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox LoadingGif;
    }
}

