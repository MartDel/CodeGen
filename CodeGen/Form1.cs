using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CodeGen
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Control test = getVersionPanel("test version", "test name", "test author", DateTime.Now, "https://www.ecosia.org");
            ListUpdate.Controls.Add(test);
        }

        private Control getVersionPanel(string version, string name, string author, DateTime dte, string url)
        {
            // Create version label
            Label versionLabel = new Label();
            versionLabel.Text = version;
            versionLabel.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            versionLabel.Dock = DockStyle.Left;
            versionLabel.AutoSize = true;

            // Create name label
            Label nameLabel = new Label();
            nameLabel.Text = name;
            nameLabel.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            nameLabel.AutoSize = true;

            // Create info label (for author and date - dte)
            Label infoLabel = new Label();
            infoLabel.Text = author + " - " + dte.ToLocalTime().ToString("d");
            infoLabel.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            infoLabel.AutoSize = true;

            // Create link picturebox
            PictureBox github_logo = new PictureBox();
            github_logo.Image = Properties.Resources.GitHub_logo;
            github_logo.SizeMode = PictureBoxSizeMode.Zoom;
            github_logo.Dock = DockStyle.Right;
            github_logo.Width = 29;
            github_logo.Cursor = Cursors.Hand;
            github_logo.Click += new EventHandler((sender, args) =>
            {
                Process.Start(url);
            });

            // Create version panel
            Panel panel = new Panel();
            panel.Width = 277;
            panel.Height = 60;
            panel.Padding = new Padding(0, 0, 5, 0);
            panel.Controls.Add(versionLabel);
            panel.Controls.Add(nameLabel);
            nameLabel.Location = new Point(2, 23);
            panel.Controls.Add(infoLabel);
            infoLabel.Location = new Point(2, 40);
            panel.Controls.Add(github_logo);
            return panel;
        }
    }
}
