using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
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
                    string sha = tag.Value<JObject>("object").Value<string>("sha");
                    string taginfo_str = GetRequest("https://api.github.com/repos/MartDel/CodeGen/git/tags/" + sha);
                    JToken taginfo = JToken.Parse(taginfo_str);
                    string version = taginfo.Value<string>("tag");
                    string name = taginfo.Value<string>("message");
                    string author = taginfo.Value<JObject>("tagger").Value<string>("name");
                    string dte_str = taginfo.Value<JObject>("tagger").Value<string>("date");
                    DateTime dte = DateTime.ParseExact(dte_str, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                    Control panel = getVersionPanel(version, name, author, dte, "https://www.github.com/MartDel/CodeGen/tree/" + version);
                    ListUpdate.Controls.Add(panel);
                }
            }
            catch (WebException ex)
            {
                WebExceptionStatus notFound = WebExceptionStatus.ProtocolError;
                if (ex.Status.Equals(notFound))
                {
                    ListUpdate.Visible = false;
                    NoTagLabel.Visible = true;
                }
                else
                {
                    NoTagLabel.Text = "Erreur...";
                    NoTagLabel.Visible = true;
                }
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
