using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruminoid.Studio.Storage
{
    public static class StorageHelper
    {
        #region Static Folders

        public static string AppFolder => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            @"Storage");

        public static string RoamingFolder => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            @"Ruminoid\Studio");

        #endregion

        public static string GetFolderToRead(string section, bool skipRoaming = false)
        {
            string folder;
            if (!skipRoaming)
            {
                folder = Path.Combine(RoamingFolder, section);
                if (Directory.Exists(folder)) return folder;
            }
            folder = Path.Combine(AppFolder, section);
            return Directory.Exists(folder) ? folder : string.Empty;
        }

        public static string GetFileToRead(string section, string name)
        {
            string folder = GetFolderToRead(section);
            string file;

            if (!string.IsNullOrEmpty(folder))
            {
                file = Path.Combine(folder, name);
                if (File.Exists(file)) return file;
            }

            folder = GetFolderToRead(section, true);

            if (!string.IsNullOrEmpty(folder))
            {
                file = Path.Combine(folder, name);
                if (File.Exists(file)) return file;
            }

            return string.Empty;
        }

        public static string GetFolderToWrite(string section)
        {
            string folder = Path.Combine(RoamingFolder, section);
            Directory.CreateDirectory(folder);
            return folder;
        }

        public static string GetFileToWrite(string section, string name)
        {
            return Path.Combine(GetFolderToWrite(section), name);
        }
    }
}
