using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

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
            public SortedDictionary<string, RevisedFile> files { get; set; }
        }

        public Project project;
        public string path;

        public void ReadProject()
        {
            byte[] compressed = Convert.FromBase64String(File.ReadAllText(path));
            byte[] decompressed = Decompress(compressed);

            project = JsonConvert.DeserializeObject<Project>(Encoding.UTF8.GetString(decompressed));
        }

        public void WriteProject()
        {
            byte[] encoded = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(project));
            byte[] compressed = Compress(encoded);

            File.WriteAllText(path, Convert.ToBase64String(compressed));
        }

        public string Comment(bool comment)
        {
            if (comment)
                return Language.Strings.Generic_Yes;

            return Language.Strings.Generic_No;
        }

        public byte[] Compress(byte[] input)
        {
            using (var result = new MemoryStream())
            {
                var lengthBytes = BitConverter.GetBytes(input.Length);
                result.Write(lengthBytes, 0, 4);

                using (var compressionStream = new GZipStream(result, CompressionMode.Compress))
                {
                    compressionStream.Write(input, 0, input.Length);
                    compressionStream.Flush();
                }

                return result.ToArray();
            }
        }

        public static byte[] Decompress(byte[] input)
        {
            using (var source = new MemoryStream(input))
            {
                byte[] lengthBytes = new byte[4];
                source.Read(lengthBytes, 0, 4);

                var length = BitConverter.ToInt32(lengthBytes, 0);
                using (var decompressionStream = new GZipStream(source, CompressionMode.Decompress))
                {
                    var result = new byte[length];
                    decompressionStream.Read(result, 0, length);
                    return result;
                }
            }
        }
    }
}
