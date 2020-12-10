using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Reviser
{
    public class ProjectFile
    {
        public class FileContent
        {
            public int contentId { get; set; }
            public string lineId { get; set; }
            public string proposal { get; set; }
            public string prevLineId { get; set; }
            public bool comment { get; set; }
            public bool color { get; set; }
        }

        public class RevisedFile
        {
            public bool complete { get; set; }
            public string note { get; set; }
            public List<FileContent> content { get; set; }
        }

        public class Project
        {
            public string name { get; set; }
            public string type { get; set; }
            public string[] file_list { get; set; }
            public string orig_path { get; set; }
            public string tran_path { get; set; }
            public Dictionary<string, RevisedFile> files { get; set; }
        }

        public Project project;
        public string path;

        public void ReadProject()
        {
            project = JsonConvert.DeserializeObject<Project>(File.ReadAllText(path));
        }

        public void WriteProject()
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(project, Formatting.Indented));
        }

        public string Comment(bool comment)
        {
            if (comment)
                return "Yes";
            else
                return "No";
        }
    }
}
