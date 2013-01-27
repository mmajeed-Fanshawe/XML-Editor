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
    }
}
