using System;

namespace CodeGen
{
    public class Project
    {
        public string Name;
        public string Description;
        public string Techno;
        public Uri Template_link = null;
        public string Path;
        public string Full_path;
        public Uri Remote = null;

        public Project(string name, string description, string techno, string path, Uri remote = null)
        {
            Name = name;
            Description = description;
            Techno = techno;
            Path = path;
            Full_path = path + "\\" + name;
            if (remote != null) { Remote = remote; }

            if (techno == "Arduino") { Template_link = new Uri("https://gitlab.com/MartDel/arduinotemplate.git"); }
        }
    }
}