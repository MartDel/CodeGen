using System.IO;

namespace CodeGen
{
    class ManageFile
    {
        public string path;
        public string name;
        public string type;
        public string full_name;
        public string full_path;

        public ManageFile(string full_path)
        {
            this.full_path = full_path;
            this.path = full_path.Substring(0, full_path.LastIndexOf('\\') + 1);
            this.full_name = full_path.Substring(full_path.LastIndexOf('\\') + 1);
            this.type = this.full_name.Substring(this.full_name.LastIndexOf('.') + 1);
            this.name = this.full_name.Substring(0, this.full_name.LastIndexOf('.'));
        }

        public void WriteToFile(string str)
        {
            StreamWriter file = new StreamWriter(this.full_path);
            file.Write(str);
            file.Flush();
            file.Close();
        }

        public string ReadInFile()
        {
            StreamReader file = new StreamReader(this.full_path);
            string r = file.ReadToEnd();
            file.Close();
            return r;
        }
    }
}
