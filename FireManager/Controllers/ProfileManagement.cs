using System;
using System.Text;
using System.Xml;
using FireManager.Models;

namespace FireManager.Controllers
{
    public class ProfileManagement
    {
        public Result CreateProfile(ConnectionData connectionData, string file)
        {
            var result = new Result();

            var fileManagement = new FileManagement();

            try
            {
                var writer = new XmlTextWriter(file, Encoding.UTF8);

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

                result.Message = "Perfil guardado";
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

            if (xmlDoc.DocumentElement != null)
            {
                var nodeList = xmlDoc.DocumentElement.SelectNodes("/DatabaseConnectionData/Profile");

                if (nodeList != null)
                    foreach (XmlNode node in nodeList)
                    {
                        var selectSingleNode = node.SelectSingleNode("ServerName");
                        if (selectSingleNode != null)
                            connectionData.ServerName = selectSingleNode.InnerText;
                        var singleNode = node.SelectSingleNode("DatabaseName");
                        if (singleNode != null)
                            connectionData.DatabaseName = singleNode.InnerText;
                        var xmlNode = node.SelectSingleNode("Password");
                        if (xmlNode != null)
                            connectionData.Password = xmlNode.InnerText;
                        var selectSingleNode1 = node.SelectSingleNode("PortNumber");
                        if (selectSingleNode1 != null)
                            connectionData.PortNumber = selectSingleNode1.InnerText;
                        var singleNode1 = node.SelectSingleNode("UserName");
                        if (singleNode1 != null)
                            connectionData.UserName = singleNode1.InnerText;
                    }
            }

            return connectionData;
        }
    }
}