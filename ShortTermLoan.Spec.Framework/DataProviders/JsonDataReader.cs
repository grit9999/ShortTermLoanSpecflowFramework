using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace ShortTermLoan.Spec.Framework.DataProviders
{
    public static class JsonDataReader
    {
        private static DirectoryInfo[] GetListOfDirectoriesInProject()
        {
            DirectoryInfo projectDirectoryInfo = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.Parent;
            DirectoryInfo[] listOfDirectoriesInProject = projectDirectoryInfo.GetDirectories();
            return listOfDirectoriesInProject;
        }

        private static bool IsNameOfFileMatchJsonFilename(string jsonFilename, FileInfo fileInfo)
        {
            string nameOfFile = fileInfo.Name;
            bool isNameOfFileMatchJsonFile = (nameOfFile.ToLower() == jsonFilename.ToLower());
            return isNameOfFileMatchJsonFile;
        }

        private static string SearchFilesInDirectoryForFullFilePath(DirectoryInfo directoryInformation, string jsonFilename)
        {
            FileInfo[] files = directoryInformation.GetFiles();
            string fullPathOfJsonFile = "";
            for (int index = 0; index < files.Length; index++)
            {
                fullPathOfJsonFile = IsNameOfFileMatchJsonFilename(jsonFilename, files[index]) ? directoryInformation.FullName + "\\" + files[index].Name : "";
                if (fullPathOfJsonFile.Length > 0)
                    break;
            }
            return fullPathOfJsonFile;
        }

        public static string GetJsonFilePath(string jsonFilename)
        {
            DirectoryInfo[] listOfDirectoriesInProject = GetListOfDirectoriesInProject();
            string fullPathOfJsonFile = "";
            foreach (DirectoryInfo directoryInfo in listOfDirectoriesInProject)
            {
                fullPathOfJsonFile = SearchFilesInDirectoryForFullFilePath(directoryInfo, jsonFilename);
                if (fullPathOfJsonFile.Contains(jsonFilename))
                    break;
            }
            return fullPathOfJsonFile;
        }

        public static Dictionary<string, string> GetJsonDataFromFile(string jsonFilename)
        {
            string filePathToUse = GetJsonFilePath(jsonFilename);
            string fileAsString = File.ReadAllText(filePathToUse);
            Dictionary<string, string> jsonData = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileAsString);
            return jsonData;
        }
    }
}
