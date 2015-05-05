using System;
using System.IO;
using FireManager.Models;

namespace FireManager.Controllers
{
    public class FileManagement
    {
         public Result SaveQueryFile(string file, string queryText)
        {
            var result = new Result();

            try
            {
                if (!string.IsNullOrWhiteSpace(file))
                {
                    File.WriteAllText(file, queryText);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            result.Success = true;
            result.Message = "Se guardó correctamente";

            return result;
        }

        public string OpenQueryFile(string file)
        {
            var queryText = "";

            try
            {
                if (!string.IsNullOrWhiteSpace(file))
                {
                    queryText = File.ReadAllText(file);
                }
            }
            catch (Exception ex)
            {
                queryText = ex.Message;
            }

            return queryText;
        }

        public Result SaveNewProfile(ConnectionData connectionData, string savePath)
        {
            var profileManager = new ProfileManagement();

            var result = profileManager.CreateProfile(connectionData, savePath);

            return result;
        }
    }
}