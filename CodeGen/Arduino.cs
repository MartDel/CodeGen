using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CodeGen
{
    public partial class Arduino : Form
    {
        public static JToken LIB = JToken.Parse(Encoding.ASCII.GetString(Properties.Resources.libraries));
        private Project project;

        public Arduino(Project project)
        {
            InitializeComponent();
            this.project = project;
        }

        private void Arduino_Load(object sender, EventArgs e)
        {
            Title.ForeColor = Home.GREEN;
        }

        private void AddComposant_Click(object sender, EventArgs e)
        {
            if(Composant.Text == "") { MessageBox.Show("Renseignez le nom du composant "); }
            else { Composants.Items.Add(Composant.Text); }
        }

        private void DeleteComposant_Click(object sender, EventArgs e)
        {
            Composants.Items.Remove(Composants.SelectedItem);
        }

        private void AddLibrary_Click(object sender, EventArgs e)
        {
            if (Library.Text == "") { MessageBox.Show("Renseignez le nom de la librairie "); }
            else { Libraries.Items.Add(Library.Text); }
        }

        private void DeleteLibrary_Click(object sender, EventArgs e)
        {
            Libraries.Items.Remove(Libraries.SelectedItem);
        }

        private void AddDatasheet_Click(object sender, EventArgs e)
        {
            if (Datasheet.Text == "") { MessageBox.Show("Renseignez le nom de la datasheet "); }
            else { Datasheets.Items.Add(Datasheet.Text); }
        }

        private void DeleteDatasheet_Click(object sender, EventArgs e)
        {
            Datasheets.Items.Remove(Datasheets.SelectedItem);
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
            string composants = "";
            if (Composants.Items.Count == 0) { composants = "Aucun composant utilisé pour l'instant..."; }
            else
            {
                foreach(string comp in Composants.Items) { composants += "* " + comp + Environment.NewLine; }
            }

            string librairies = "";
            if (Libraries.Items.Count == 0) { librairies = "Aucune librairies utilisée pour l'instant..."; }
            else
            {
                foreach (string lib in Libraries.Items) { librairies += "* " + lib + Environment.NewLine; }
            }

            // Create thread
            Thread dl = new Thread(() =>
            {
                // Write on README.md
                /*
                ManageFile readme = new ManageFile(project.Full_path + "\\README.md");
                string readme_content = readme.ReadInFile();
                readme_content = readme_content.Replace("<ListeComposant>", composants);
                readme_content = readme_content.Replace("<ListeLibrairie>", librairies);
                readme.WriteToFile(readme_content);
                */

                Directory.CreateDirectory(project.Full_path + "\\Libraries");
                foreach (string lib in Libraries.Items)
                {
                    string url = LIB.Value<string>(lib);
                    ManageFile.DlFile(url, project.Full_path + "\\Libraries", lib + ".zip");
                }

            });
            dl.Start();
        }
    }
}