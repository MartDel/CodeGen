using Newtonsoft.Json.Linq;
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
        private delegate void SafeCallDelegate(string techno);
        public static string Resources = Encoding.ASCII.GetString(Properties.Resources.resources);
        public static Color GREEN;
        public API github = new API(new Uri("https://api.github.com"));
        public Project project;
        //public Project p = new Project("Test", "duezbf", "Arduino", @"C:\Users\marti\Desktop");

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

            // Check if Git is installed
            string git_version = execCmd("git --version", "current");
            if (!git_version.Contains("version"))
            {
                DialogResult response = MessageBox.Show("Veuillez installer Git et lui donner la permission d'être exécuter sur l'invite de commande Windows (cmd)", "Git n'est pas installer", MessageBoxButtons.OKCancel);
                if (response.Equals(DialogResult.OK)){ Process.Start("https://git-scm.com/downloads"); }
                this.Close();
            }
            
            // Generate tags list
            try
            {
                // If you don't want print the version list :
                // Uncomment the following line
                // throw new WebException();
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

                project = new Project(NameTxtBox.Text, DescriptionTxtBox.Text, TechnoTxtBox.Text, FolderTxtBox.Text, remote);

                // Create thread
                Thread configure = new Thread(() =>
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
                    OpenNewForm(project.Techno);
                });

                ValidateBtn.Visible = false;
                LoadingGif.Visible = true;

                configure.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenNewForm(string techno)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    OpenNewForm(techno);
                }));
                return;
            }

            ValidateBtn.Visible = true;
            LoadingGif.Visible = false;

            if (techno == "Arduino") {
                Arduino form = new Arduino(project);
                form.FormClosing += new FormClosingEventHandler(formClosing);
                this.Hide();
                form.Show();
            }
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult closing = MessageBox.Show("Voulez-vous fermer le logiciel ?", "Fermer la fenêtre", MessageBoxButtons.YesNoCancel);
            if (closing.Equals(DialogResult.Yes)) { this.Close(); }
            else if (closing.Equals(DialogResult.No)) { this.Show(); }
            else if (closing.Equals(DialogResult.Cancel)) { e.Cancel = true; }
            else { e.Cancel = true; }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Arduino form = new Arduino(project);
            form.FormClosing += new FormClosingEventHandler((send, args) =>
            {
                DialogResult closing = MessageBox.Show("Voulez-vous fermer le logiciel ?", "Fermer la fenêtre", MessageBoxButtons.YesNoCancel);
                if (closing.Equals(DialogResult.Yes)) { this.Close(); }
                else if (closing.Equals(DialogResult.No)) { this.Show(); }
                else if (closing.Equals(DialogResult.Cancel)) { args.Cancel = true; }
                else { args.Cancel = true; }
            });
            this.Hide();
            form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //OpenNewForm(p.Techno);
        }
    }
}
