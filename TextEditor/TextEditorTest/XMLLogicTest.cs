using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextEditorLibrary;

namespace TextEditorTest
{
    using NUnit.Framework;
    using System.Xml;

    /// <summary>Some Tests for the XMLogic file</summary>
    [TestFixture] 
    class XMLLogicTest
    {
        public const string xsdFile = @"..\..\Resources\XMLSchema.xsd";
        public const string xmlFile = @"..\..\Resources\XMLFile.xml";

        public const string xmlFileContant =    @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
                                                <note>
                                                    <to>To</to>
                                                    <from>From</from>
                                                    <heading>Reminder</heading>
                                                    <body>Don't forget me this weekend!</body>
                                                </note>";

        /// <summary>
        /// Init the test with the right data
        /// </summary>
        [SetUp]
        public void Init()
        {
            // Open the file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(xmlFile))
            {
                file.WriteLine(xmlFileContant); // Write to file
            }
        }

        /// <summary>
        /// Test for opening a file
        /// </summary>
        [Test]
        public void OpenFile()
        {
            Init();
            XMLLogic xml = new XMLLogic();
            string xmlContent = xml.OpenFile(xmlFile);
            Assert.AreEqual(xmlContent.Trim(), xmlFileContant.Trim());
        }

        /// <summary>
        /// Test for opening a file
        /// </summary>
        [Test]
        [ExpectedException(typeof(Exception))]
        public void OpenFileDosntExist()
        {
            Init();
            XMLLogic xml = new XMLLogic();
            string xmlContent = xml.OpenFile("WrongTypeOfFile.xml");
            Assert.AreEqual(xmlContent.Trim(), xmlFileContant.Trim());
        }
        
        /// <summary>
        /// Test for saving a file
        /// </summary>
        [Test]
        public void SaveFile()
        {
            Init();
            // Opening the file, editing it then saving
            XMLLogic xml = new XMLLogic();
            string xmlContent = xml.OpenFile(xmlFile);
            string newEditedXml = xmlContent.Replace("Reminder", "Reminder2");
            xml.SaveFile(newEditedXml);

            // Open it again and check that the change did happen
            XMLLogic xml2 = new XMLLogic();
            string xmlContent2 = xml2.OpenFile(xmlFile);
            Assert.AreEqual(xmlContent2.Trim(), newEditedXml.Trim());
        }
        
        /// <summary>
        /// Test for saving a file as
        /// </summary>
        [Test]
        public void SaveAsFile()
        {
            Init();
            // Opening the file, editing it then saving
            XMLLogic xml = new XMLLogic();
            string xmlContent = xml.OpenFile(xmlFile);
            string newEditedXml = xmlContent.Replace("From", "To");
            xml.SaveFile(newEditedXml, @"..\..\Resources\XMLFileEdited.xml");

            // Open it again and check that the change did happen
            XMLLogic xml2 = new XMLLogic();
            string xmlContent2 = xml2.OpenFile(@"..\..\Resources\XMLFileEdited.xml");
            Assert.AreEqual(xmlContent2.Trim(), newEditedXml.Trim());
        }

        /// <summary>
        /// Test for saving a file as with invalid xml
        /// </summary>
        [Test]
        [ExpectedException(typeof(XmlException))]
        public void SaveAsFileInvalidXml()
        {
            Init();
            // Opening the file, editing it then saving
            XMLLogic xml = new XMLLogic();
            string xmlContent = xml.OpenFile(xmlFile);
            string newEditedXml = xmlContent.Replace("</note>", "");
            xml.SaveFile(newEditedXml, xmlFile);

            // Open it again and check that the change did not happen
            XMLLogic xml2 = new XMLLogic();
            string xmlContent2 = xml2.OpenFile(xmlFile);
            Assert.AreNotEqual(xmlContent2.Trim(), newEditedXml.Trim());
        }

        /// <summary>
        /// Test for saving a file with an- xml that dosn't match the xsd
        /// </summary>
        [Test]
        [ExpectedException(typeof(Exception))]
        public void SaveAsFileInvalidXSD()
        {
            Init();
            // Opening the file, editing it then saving
            XMLLogic xml = new XMLLogic();
            string xmlContent = xml.OpenFile(xmlFile);
            string newEditedXml = xmlContent.Replace("<from>From</from>", "");
            xml.SaveFile(newEditedXml, xmlFile);

            // Open it again and check that the change did not happen
            XMLLogic xml2 = new XMLLogic();
            string xmlContent2 = xml2.OpenFile(xmlFile);
            Assert.AreNotEqual(xmlContent2.Trim(), newEditedXml.Trim());
        }
    }
}
