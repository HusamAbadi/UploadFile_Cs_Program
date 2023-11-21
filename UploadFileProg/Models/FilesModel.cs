using System.IO;

namespace UploadFileProg.Models
{
    public class FilesModel
    {
        public List<string>? FileNames { get; set; }
        public FilesModel(string path)
        {
            FileNames = Directory.EnumerateFiles(path)
                .Select(x => x.Substring(path.Length)).ToList();
        }
    }
}
