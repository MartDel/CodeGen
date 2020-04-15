﻿using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CodeGen
{
    public partial class Home : Form
    {
        public static string Resources = Encoding.ASCII.GetString(Properties.Resources.resources);
        public static Color GREEN;
        private API github = new API(new Uri("https://api.github.com"));

        public Home()
        {
            InitializeComponent();
            JObject colors = JToken.Parse(Resources).Value<JObject>("colors");
            JObject g = colors.Value<JObject>("green");
            int red = g.Value<int>("red");
            int green = g.Value<int>("green");
            int blue = g.Value<int>("blue");
            GREEN = Color.FromArgb(red, green, blue);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (!checkConnection())
            {
                MessageBox.Show("Pas de connexion Internet...");
                this.Close();
                return;
            }
            
            // Generate tags list
            try
            {
                string tags_str = github.GetRequest("repos/MartDel/CodeGen/git/refs/tags", true);
                JToken tags = JToken.Parse(tags_str);
                foreach (JObject tag in tags)
                {
                    string url = tag.Value<JObject>("object").Value<string>("url");
                    string taginfo_str = github.GetRequest(url, false);
                    JToken taginfo = JToken.Parse(taginfo_str);
                    string version = taginfo.Value<string>("tag");
                    string name = taginfo.Value<string>("message");
                    if(name.Length > 30)
                    {
                        name = name.Substring(0, 30);
                        name = name + "...";
                    }
                    string author = taginfo.Value<JObject>("tagger").Value<string>("name");
                    string dte_str = taginfo.Value<JObject>("tagger").Value<string>("date");
                    DateTime dte = DateTime.Parse(dte_str, CultureInfo.GetCultureInfo("en-US"));
                    Control panel = getVersionPanel(version, name, author, dte, "https://www.github.com/MartDel/CodeGen/tree/" + version);
                    ListUpdate.Controls.Add(panel);
                }
                for(int i = 0; i < ListUpdate.Controls.Count; i++)
                {
                    int length = ListUpdate.Controls.Count - 1;
                    Control control = ListUpdate.Controls[0];
                    ListUpdate.Controls.SetChildIndex(control, length - i);
                }
            }
            catch (WebException ex)
            {
                ListUpdate.Visible = false;
                WebExceptionStatus notFound = WebExceptionStatus.ProtocolError;
                if (ex.Status.Equals(notFound))
                {
                    NoTagLabel.Visible = true;
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    ErrorLabel.Visible = true;
                }
            }
        }

        private void ValidateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check all of txtbox
                if (NameTxtBox.Text == "") { throw new Exception("Donnez un nom au projet"); }
                if (DescriptionTxtBox.Text == "") { throw new Exception("Donnez une description au projet"); }
                if (FolderTxtBox.Text == "") { throw new Exception("Indiquez le dossier du projet"); }
                else if (!Directory.Exists(FolderTxtBox.Text)) { throw new Exception("Le dossier indiqué n'éxiste pas"); }
                if (TechnoTxtBox.Text != "Arduino") { throw new Exception("Template invalide"); }

                Uri remote;
                if (RemoteTxtBox.Text != "")
                {
                    try { remote = new Uri(RemoteTxtBox.Text); }
                    catch (UriFormatException) { throw new Exception("L'url du remote n'est pas correct"); }
                }
                else { remote = null; }

                Project project = new Project(NameTxtBox.Text, DescriptionTxtBox.Text, TechnoTxtBox.Text, FolderTxtBox.Text, remote);

                // Create thread
                Thread configue = new Thread(() =>
                {
                    // Clone the template
                    execCmd("git clone " + project.Template_link, project.Path);

                    // Configure the project folder
                    execCmd("ren " + project.Techno.ToLower() + "template " + project.Name, project.Path);
                    execCmd("git remote remove origin", project.Full_path);
                    ManageFile readme = new ManageFile(project.Full_path + "\\README.md");
                    string readme_content = readme.ReadInFile();
                    readme_content = readme_content.Replace("<NomDuProjet>", project.Name);

                    // Optionals features
                    if (project.Remote != null)
                    {
                        execCmd("git remote add origin " + project.Remote.AbsoluteUri, project.Full_path);
                        readme_content = readme_content.Replace("<InsérerDescription>", project.Description + Environment.NewLine + Environment.NewLine + "**Lien du remote :** [" + project.Name + "](" + project.Remote.AbsoluteUri + ")");
                    }
                    else
                    {
                        readme_content = readme_content.Replace("<InsérerDescription>", project.Description);
                    }

                    readme.WriteToFile(readme_content);
                    MessageBox.Show("Terminé!");
                });

                ValidateBtn.Visible = false;
                LoadingGif.Visible = true;
                configue.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                FolderTxtBox.Text = folderDlg.SelectedPath;
            }
        }

        private bool checkConnection()
        {
            Uri objUrl = new Uri("https://www.google.fr");
            WebRequest objWebReq = WebRequest.Create(objUrl);
            WebResponse objResp;
            try
            {
                objResp = objWebReq.GetResponse();
                objResp.Close();
                objResp = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string execCmd(string cmd, string cd)
        {
            Process process = new Process();
            if (cd != "current")
            {
                process.StartInfo.WorkingDirectory = cd;
            }
            process.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            process.StartInfo.Arguments = "/c " + cmd;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            StreamReader test = process.StandardOutput;
            return test.ReadToEnd();
        }

        private Control getVersionPanel(string version, string name, string author, DateTime dte, string url)
        {
            // Create version label
            Label versionLabel = new Label();
            versionLabel.Text = version;
            versionLabel.ForeColor = GREEN;
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
