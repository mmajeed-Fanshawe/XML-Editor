using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TextEditor
{
    /// <summary>
    /// Class that will hold all the logic for opening and saving files
    /// </summary>
    public static class XMLLogic
    {
        public static string OpenFile(string fileLocation)
        {
            if (!File.Exists(fileLocation))
            {
                throw new Exception("File not found");
            }

            try
            {
                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    String text = sr.ReadToEnd();
                    return text;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file: " + ex.Message);
            }
        }
    }
}
