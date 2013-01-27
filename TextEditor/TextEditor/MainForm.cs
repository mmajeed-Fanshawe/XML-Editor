using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextEditor
{
    /// <summary>
    /// The MainForm class that holds the logic for the main window
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// XmlFile that will hold the logic for saving and deleting
        /// </summary>
        XMLLogic xmlFile = new XMLLogic();

        /// <summary>
        /// Init
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handler for the close toostrip that will close the file
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handler for the New toolstip that will clear the textbox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTBXML.Clear();
        }

        /// <summary>
        /// Handler for the open toolstip that will open a new textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "XML Files (.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    string xmlText = xmlFile.OpenFile(openFileDialog1.FileName);
                    RTBXML.Text = xmlText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error has occured opening the file");
                }
            }
        }
    }
}
