using System;
using System.Text;
using System.Xml;

namespace FireManager
{
    public class ProfileManagement
    {
        public Result CreateProfile(ConnectionData connectionData, string file)
        {
            var result = new Result();

            var fileManagement = new FileManagement();

            try
            {
                XmlTextWriter writer = new XmlTextWriter(file, Encoding.UTF8);

                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;

                writer.WriteStartElement("DatabaseConnectionData");

                writer.WriteStartElement("Profile");

                writer.WriteStartElement("ServerName");
                writer.WriteString(connectionData.ServerName);
                writer.WriteEndElement();

                writer.WriteStartElement("PortNumber");
                writer.WriteString(connectionData.PortNumber);
                writer.WriteEndElement();

                writer.WriteStartElement("UserName");
                writer.WriteString(connectionData.UserName);
                writer.WriteEndElement();

                writer.WriteStartElement("Password");
                writer.WriteString(connectionData.Password);
                writer.WriteEndElement();

                writer.WriteStartElement("DatabaseName");
                writer.WriteString(connectionData.DatabaseName);
                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Close();

                result.Message = "Profile Was Saved";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public ConnectionData GetSavedProfile(string filePath)
        {
            var connectionData = new ConnectionData();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            var nodeList = xmlDoc.DocumentElement.SelectNodes("/DatabaseConnectionData/Profile");

            foreach (XmlNode node in nodeList)
            {
                connectionData.ServerName = node.SelectSingleNode("ServerName").InnerText;
                connectionData.DatabaseName = node.SelectSingleNode("DatabaseName").InnerText;
                connectionData.Password = node.SelectSingleNode("Password").InnerText;
                connectionData.PortNumber = node.SelectSingleNode("PortNumber").InnerText;
                connectionData.UserName = node.SelectSingleNode("UserName").InnerText;
            }

            return connectionData;
        }
    }
}