using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace TextEditorLibrary
{
    /// <summary>
    /// Class that will hold all the logic for opening and saving files
    /// </summary>
    public class XMLLogic
    {
        /// <summary>
        /// This will contain the location of the xst file
        /// </summary>
        public const string xsdFile = @"..\..\Resources\XMLSchema.xsd";

        /// <summary>
        /// This remembers the current file that is open
        /// </summary>
        public string fileCurrentlyOpen;

        /// <summary>
        ///  Will open the file for you and return it is content
        ///  Will throw exception  if loading file fails
        /// </summary>
        /// <param name="fileLocation">A path to the location of the XML file</param>
        /// <returns>A string that contains the XML information that was loaded from the file</returns>
        public string OpenFile(string fileLocation)
        {
            // Check if file exists
            if (!File.Exists(fileLocation))
            {
                throw new Exception("File not found");
            }

            try
            {
                // Open a stream
                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    // Copy the text
                    String text = sr.ReadToEnd();
                    // Save the file location
                    fileCurrentlyOpen = fileLocation;
                    return text;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file: " + ex.Message);
            }
        }

        
        /// <summary>
        /// Will save xmlDocument to where  fileCurrentlyOpen is currently set
        /// Will throw an exception if it fails save the file
        /// </summary>
        /// <param name="xmlDocument">XML Information You want saved</param>
        public void SaveFile(string xmlDocument)
        {
            this.SaveFile(xmlDocument, fileCurrentlyOpen);
        }

        /// <summary>
        /// Will save xmlDocument to where  fileLocation is currently set
        /// Will throw an exception if it fails save the file
        /// </summary>
        /// <param name="xmlDocument">XML Information You want saved</param>
        /// <param name="fileLocation">Location of where to save the file</param>
        public void SaveFile(string xmlDocument, string fileLocation)
        {
            // Check if file exists
            if (!File.Exists(xsdFile))
            {
                throw new Exception("xsd file could not found");
            }

            // create an xml
            XmlDocument xmld = new XmlDocument();
            xmld.LoadXml(xmlDocument);
            xmld.Schemas.Add(null, xsdFile);

            try
            {
                // This will throw if it fails
                xmld.Validate((object sender, ValidationEventArgs e) => { throw new Exception("XML Document dosn't match XSD"); });
            }
            catch (Exception ex)
            {
                // Catch the error and rethrow it, maybe put a logger in there for future
                throw ex;
            }

            try
            {
                // Open the file
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileLocation))
                {
                    file.WriteLine(xmlDocument); // Write to file
                }
            }
            catch (Exception ex)
            {
                // Error happened, manaage it
                throw new Exception("An error occured while saving: " + ex.Message);
            }



        }
    }
}
