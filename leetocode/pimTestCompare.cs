using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetocode
{
    internal class pimTestCompare
    {

        public void CompareFiles()
        {
            string[] oldFiles = Directory.GetFiles(@"C:\Users\fischert\Desktop\testOutputPIMAPI", "*old*.xml", SearchOption.TopDirectoryOnly);
            string[] newFiles = Directory.GetFiles(@"C:\Users\fischert\Desktop\testOutputPIMAPI", "*new*.xml", SearchOption.TopDirectoryOnly);
            List<string> oldFilesWithoutOld = oldFiles.Select(f => f.Replace("old_", "")).ToList();

            for (var i = 0; i < newFiles.Length; i++)
            {
                string newFile = newFiles[i];
                string newFileWithoutNew = newFile.Replace("new_", "");
                int oldIndex = oldFilesWithoutOld.IndexOf(newFileWithoutNew);

                Byte[] file1 = File.ReadAllBytes(newFile);
                Byte[] file2 = File.ReadAllBytes(oldFiles[oldIndex]);

                // if (f1 == f2) -> probably does the same 
                if (AreFilesEqual(file1, file2))
                {
                    File.Delete(newFile);
                    File.Delete(oldFiles[oldIndex]);
                }

            }

        }


        public bool AreFilesEqual(Byte[] f1, Byte[] f2)
        {
            if (f1.Length != f2.Length)
                return false;
            for (var i = 0; i < f1.Length; i++)
            {
                if (f1[i] != f2[i])
                    return false;
            }
            return true;
        }

        public void WriteTestFile()
        {
            string dirPath = @"C:\Users\fischert\Downloads\navision_logfiles";

            string[] logfiles = Directory.GetFiles(dirPath);

            List<string> commands = new List<string>();

            foreach (var logfile in logfiles)
            {
                var file = File.ReadAllLines(logfile);
                foreach (var line in file)
                {
                    commands.Add(GetArticelNumber(line));
                }
            }

            var onlyCommands = commands.Where(x => x != "").ToArray();

            File.WriteAllLines("commands.txt", onlyCommands);
        }

        public string GetArticelNumber(string line)
        {
            var words = line.Split(' ');

            var index = Array.IndexOf(words, "-Articleno");
            if (index == -1)
            {
                return "";
            }
            else
            {
                return @$"C:\Users\fischert\Desktop\projects\gitlabProjects\iPim-NavisionAdapter\IpimNavisionAdapter\bin\Debug\IpimNavisionAdapter.exe -Articleno {words[index + 1]} -dd"; ;
            }
        }
    }
}