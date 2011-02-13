﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration.Install;
using System.Xml;
using System.Runtime.InteropServices;

namespace CprBroker.Engine.Util
{
    /// <summary>
    /// Utility class with methods that assist the installation process by extending the Installer class
    /// </summary>
    public static class Installation
    {
        /// <summary>
        /// Returns the full path of the currently executing exe installer
        /// </summary>
        /// <param name="installer"></param>
        /// <returns></returns>
        public static string GetInstallerAssemblyFilePath(this Installer installer)
        {
            return installer.Context.Parameters["assemblypath"]; ;
        }

        /// <summary>
        /// Returns the full path of the config file related to the current exe
        /// </summary>
        /// <param name="installer"></param>
        /// <returns></returns>
        public static string GetInstallerAssemblyConfigFilePath(this Installer installer)
        {
            return installer.GetInstallerAssemblyFilePath() + ".config";
        }

        /// <summary>
        /// Returns the full path of the folder containing the current exe
        /// </summary>
        /// <param name="installer"></param>
        /// <returns></returns>
        public static string GetInstallerAssemblyFolderPath(this Installer installer)
        {
            string exePath = installer.GetInstallerAssemblyFilePath();
            FileInfo fileInfo = new FileInfo(exePath);
            return fileInfo.Directory.FullName;
        }

        public static string GetWebFolderPath(this Installer installer)
        {
            var installerAssemblyDir = new DirectoryInfo(installer.GetInstallerAssemblyFolderPath());
            return installerAssemblyDir.Parent.FullName;
        }
        /// <summary>
        /// Gets the full path of the web config of the file that contains the current exe installer
        /// </summary>
        /// <param name="installer"></param>
        /// <returns></returns>
        public static string GetWebConfigFilePathFromInstaller(this Installer installer)
        {
            var webDir = new DirectoryInfo(installer.GetWebFolderPath());
            string configFileName = webDir + "\\web.config";
            return configFileName;
        }

        /// <summary>
        /// XPath of the connection string node in config files
        /// </summary>
        public static readonly string ConnectionStringNodePath = "//connectionStrings/add[@name='CprBroker.Config.Properties.Settings.CPRConnectionString']";

        public static XmlNode GetConnectionStringsNode(string configFileName)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(configFileName);
            XmlNode connectionStringNode = doc.SelectSingleNode(ConnectionStringNodePath);
            if (connectionStringNode != null)
            {
                if (connectionStringNode.Attributes["configSource"] == null)
                {
                    return connectionStringNode;
                }
                else
                {
                    var connectionStringsFileName = new FileInfo(configFileName).Directory.FullName + "\\" + connectionStringNode.Attributes["configSource"].Value;
                    var connectionStringsDoc = new XmlDocument();
                    connectionStringsDoc.Load(connectionStringsFileName);
                    return connectionStringsDoc.SelectSingleNode("//connectionStrings");
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the connection string fromDate the web.config file of the current installer
        /// </summary>
        /// <param name="installer"></param>
        /// <returns></returns>
        public static string GetConnectionStringFromWebConfig(this Installer installer)
        {
            string configFileName = installer.GetWebConfigFilePathFromInstaller();
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(configFileName);
                XmlNode connectionStringNode = doc.SelectSingleNode(ConnectionStringNodePath);
                if (connectionStringNode != null)
                {
                    return connectionStringNode.Attributes["connectionString"].Value;
                }
            }
            catch (Exception)
            { }
            return CprBroker.Config.Properties.Settings.Default.CprBrokerConnectionString;
        }

        /// <summary>
        /// Sets the connection string value in the given config file
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="configFilePath"></param>
        /// <param name="connectionString"></param>
        public static void SetConnectionStringInConfigFile(string configFilePath, string connectionString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFilePath);
            XmlNode connectionStringNode = doc.SelectSingleNode(Installation.ConnectionStringNodePath);
            connectionStringNode.Attributes["connectionString"].Value = connectionString;
            doc.Save(configFilePath);
        }

        const int MAX_PATH = 256;
        public static string GetNetFrameworkDirectory()
        {
            StringBuilder buf = new StringBuilder(
                MAX_PATH, MAX_PATH);
            int cch = MAX_PATH;
            int hr = GetCORSystemDirectory(
                buf, MAX_PATH, ref cch);
            if (hr < 0) Marshal.ThrowExceptionForHR(hr);
            return buf.ToString();
        }

        [DllImport("mscoree.dll",
         CharSet = CharSet.Unicode,
         ExactSpelling = true)]
        public static extern int GetCORSystemDirectory(
                StringBuilder buf,
                int cchBuf,
                ref int cchRequired);

        public static CprBroker.Engine.UI.WindowHandleWrapper InstallerWindowWrapper(this Installer installer)
        {
            return new CprBroker.Engine.UI.WindowHandleWrapper(installer.Context.Parameters["productName"]);
        }
    }
}
