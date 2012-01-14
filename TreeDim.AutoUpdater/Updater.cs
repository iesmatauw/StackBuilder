#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
#endregion

namespace TreeDim.AutoUpdater
{
    public class Updater
    {
        #region Data members
        /// <summary>
        /// List of info from download info file
        /// </summary>
        private List<string> _updateInfoList;
        private string _resourceDownloadFolder;
        #endregion

        #region Constructor
        public Updater()
        {
            _resourceDownloadFolder = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetTempFileName()));        
        }
        #endregion

        #region Update method
        public bool Update()
        { 
            if (NeedUpdating)
                if (UserAccept())
                {
                    string processToEnd = Path.GetFileName(Application.ExecutablePath);
                    string postProcess = Application.ExecutablePath;
                    string updater = Path.Combine(Application.StartupPath, "TreeDim.Update.exe");
                    Updater.installUpdateRestart(_updateInfoList[3], _updateInfoList[4], _resourceDownloadFolder, processToEnd, postProcess, string.Empty, updater);
                    return true;
                }
            return false;
        }

        /// <summary>
        /// True if a newer version of the application exists on the web
        /// </summary>
        public bool NeedUpdating
        {
            get
            {
                try
                {
                    // get update info
                    _updateInfoList = Updater.getUpdateInfo(
                        Properties.Settings.Default.DownloadURL
                        , Properties.Settings.Default.VersionFile
                        , _resourceDownloadFolder
                        , 1 // second line
                        );
                    if (null == _updateInfoList)
                        return false; // returned list is null -> failed downloading or reading file
                    else
                        return CompareVersions(_updateInfoList[1], Application.ProductVersion) > 0;
                }
                catch (Exception /*ex*/)
                {
                    return false;
                }
            }
        }
        
        /// <summary>
        /// Ask user if he wants to update the application now
        /// </summary>
        /// <returns>True if user accepts </returns>
        private bool UserAccept()
        {
            return (DialogResult.Yes == MessageBox.Show(
                string.Format(Properties.Resource.ID_UPDATEAPPLICATION
                , Application.ProductName
                , Application.ProductVersion
                , _updateInfoList[1])
                , Application.ProductName
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question)
                );
        }
        #endregion

        #region Helpers
        /// <summary>Get update and version information from specified online file - returns a List</summary>
        /// <param name="downloadsURL">URL to download file from</param>
        /// <param name="versionFile">Name of the pipe| delimited version file to download</param>
        /// <param name="resourceDownloadFolder">Folder on the local machine to download the version file to</param>
        /// <param name="startLine">Line number, of the version file, to read the version information from</param>
        /// <returns>List containing the information from the pipe delimited version file</returns>
        public static List<string> getUpdateInfo(string downloadsURL, string versionFile, string resourceDownloadFolder, int startLine)
        {
            //create download folder if it does not exist
            if (!Directory.Exists(resourceDownloadFolder))
                Directory.CreateDirectory(resourceDownloadFolder);
            //let's try and download update information from the web
            if (WebData.downloadFromWeb(downloadsURL, versionFile, resourceDownloadFolder))
                return populateInfoFromWeb(versionFile, resourceDownloadFolder, startLine);
            else
                return null; // there is a chance that the download of the file was not successful

        }

        private static List<string> populateInfoFromWeb(string versionFile, string resourceDownloadFolder, int line)
        {
            List<string> tempList = new List<string>();
            int ln = 0;
            foreach (string strline in File.ReadAllLines(Path.Combine(resourceDownloadFolder, versionFile)))
            {
                if (ln == line)
                {
                    string[] parts = strline.Split('|');
                    foreach (string part in parts)
                        tempList.Add(part);
                    return tempList;
                }
                ln++;
            }
            return null;
        }

        /// <summary>Starts the update application passing across relevant information</summary>
        /// <param name="downloadsURL">URL to download file from</param>
        /// <param name="filename">Name of the file to download</param>
        /// <param name="destinationFolder">Folder on the local machine to download the file to</param>
        /// <param name="processToEnd">Name of the process to end before applying the updates</param>
        /// <param name="postProcess">Name of the process to restart</param>
        /// <param name="startupCommand">Command line to be passed to the process to restart</param>
        /// <param name="updater"></param>
        /// <returns>Void</returns>
        private static void installUpdateRestart(string downloadsURL, string filename, string destinationFolder, string processToEnd, string postProcess, string startupCommand, string updater)
        {
            string cmdLn = string.Empty;
            cmdLn += "|downloadFile|" + filename;
            cmdLn += "|URL|" + downloadsURL;
            cmdLn += "|destinationFolder|" + destinationFolder;
            cmdLn += "|processToEnd|" + processToEnd;
            cmdLn += "|postProcess|" + postProcess;
            cmdLn += "|command|" + startupCommand;

            if (!File.Exists(updater))
            {
                MessageBox.Show(Properties.Resource.ID_UPDATERNOTFOUND, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = updater;
            startInfo.Arguments = cmdLn;
            Process.Start(startInfo);
        }

        /// <summary>
        /// Compare versions of form "1,2,3,4" or "1.2.3.4". Throws FormatException
        /// in case of invalid version.
        /// </summary>
        /// <param name="strA">the first version</param>
        /// <param name="strB">the second version</param>
        /// <returns>less than zero if strA is less than strB, equal to zero if
        /// strA equals strB, and greater than zero if strA is greater than strB</returns>
        public static int CompareVersions(String strA, String strB)
        {
            Version vA = new Version(strA.Replace(",", "."));
            Version vB = new Version(strB.Replace(",", "."));

            return vA.CompareTo(vB);
        }
        #endregion
    }
}
