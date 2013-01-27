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
    public class XMLLogic
    {
        /// <summary>
        /// This remembers the current file that is open
        /// </summary>
        public string fileCurrentlyOpen;

        /// <summary>
        ///  Will open the file for you and return it is content
        /// </summary>
        /// <param name="fileLocation">A path to the location of the XML file</param>
        /// <returns>A string that contains the XML information that was loaded from the file</returns>
        public string OpenFile(string fileLocation)
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
                    fileCurrentlyOpen = fileLocation;
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
