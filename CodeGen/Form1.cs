using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace CodeGen
{
    public partial class Home : Form
    {
        public static Color GREEN = Color.FromArgb(74, 235, 53);

        public Home()
        {
            InitializeComponent();
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
                string tags_str = GetRequest("https://api.github.com/repos/MartDel/CodeGen/git/refs/tags");
                JToken tags = JToken.Parse(tags_str);
                foreach (JObject tag in tags)
                {
                    string url = tag.Value<JObject>("object").Value<string>("url");
                    string taginfo_str = GetRequest(url);
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

                string template_link;
                if (TechnoTxtBox.Text == "Arduino"){ template_link = "https://gitlab.com/MartDel/arduinotemplate.git"; }
                else{ throw new Exception("Template invalide"); }
                string techno = TechnoTxtBox.Text;

                // Create thread
                Thread configue = new Thread(() =>
                {
                    // Clone the template
                    execCmd("git clone " + template_link, FolderTxtBox.Text);

                    // Configure the project folder
                    execCmd("ren " + techno.ToLower() + "template " + NameTxtBox.Text, FolderTxtBox.Text);
                    ManageFile readme = new ManageFile(FolderTxtBox.Text + "\\" + NameTxtBox.Text + "\\README.md");
                    string readme_content = readme.ReadInFile();
                    readme_content = readme_content.Replace("<NomDuProjet>", NameTxtBox.Text);

                    // Optionals features
                    if (RemoteTxtBox.Text != "")
                    {
                        Uri remote_link = new Uri(RemoteTxtBox.Text);
                        execCmd("git remote add origin " + remote_link.AbsoluteUri, FolderTxtBox.Text + "\\" + NameTxtBox.Text);
                        readme_content = readme_content.Replace("<InsérerDescription>", DescriptionTxtBox.Text + Environment.NewLine + Environment.NewLine + "**Lien du remote :** [" + NameTxtBox.Text + "](" + remote_link.AbsoluteUri + ")");
                    }
                    readme_content = readme_content.Replace("<InsérerDescription>", DescriptionTxtBox.Text);

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

        public string GetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 10000;
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json";
            request.UserAgent = "martdel";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            response.Close();
            reader.Close();
            return result;
        }
    }
}
