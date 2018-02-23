// Author: Alex Smith
// Date: 23/2/18
// Description: A c# script that reads, writes and saves data from a text file.
using System;
using System.IO;
using System.Windows.Forms;

namespace HiScoreTable
{
    public partial class FrmHiScore : Form
    {
        // Declaring private variables.
        // '_mPreviousScore' is used when inputing a score value via the scroll bar.
        private static int _mPreviousScore;    // String
        // '_mFileName' is the text document that the script reads during startup.
        private static string _mFileName;    //String

        public FrmHiScore()
        {
            // Creates and initializes the user interface/form.
            InitializeComponent();

            // Reading and importing data.
            // The following tells the script to read from the file 'HiScore.txt' (a text file).
            _mFileName = "HiScore.txt";
        }

        // Importing data from '_mFileName'.
        // The following imports data from '_mFileName' on the form's initial startup.
        private void FrmHiScore_Load(object sender, EventArgs e)
        {
            // StreamReader is used to read the variable 'file'.
            using (var file = new StreamReader(_mFileName))
            {
                string line; // String
                // 'While reading lines from the file...'
                while ((line = file.ReadLine()) != null)
                {
                    // Print past entries from the text file to the listbox.
                    listHighScore.Items.Add(line);
                }
                // Stops reading the file once all lines have been read.
                file.Close();
            }
        }

        // Add button.
        // Adds a user entered record to the text document.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Adds 'txtName' (username) and 'txtScore' (score) to 'listHighScore' (the listbox) as an item.
            // The colon is here purely for formatting so that a record is printed as 'username:score'.
            listHighScore.Items.Add(txtName.Text + ":" + txtScore.Text);
        }

        // Remove button.
        // Removes a user entered record from the text document.
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // The variable 'index' is the record the user selects with their mouse.
            var index = listHighScore.SelectedIndex;
            // The variable 'index' is then removed from the listbox and text file.
            listHighScore.Items.RemoveAt(index);
        }

        // Formating and error handling.
        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            // For convenice shake, the program starts by selecting the top value from the listbox.
            var selectValue = txtScore.SelectionStart;

            // The string is then parsed into an integer.
            if (int.TryParse(txtScore.Text, out var scoreValue))
            {
                // Users can't give a value higher than 9999.
                if (scoreValue > 9999) scoreValue = _mPreviousScore;
                _mPreviousScore = scoreValue;
                // Converts the integer back into a printable string.
                txtScore.Text = scoreValue.ToString();
                txtScore.SelectionStart = txtScore.Text.Length >= selectValue ? txtScore.Text.Length : selectValue;
            }
            else
            {
                // The last couple of lines do the same as the code above, but for when the
                // program can't find a previous score or if the user hasn't entered a score.
                if (_mPreviousScore != 0 && txtScore.Text != "")
                {
                    txtScore.Text = _mPreviousScore.ToString();
                    txtScore.SelectionStart =
                        txtScore.Text.Length >= selectValue ? txtScore.Text.Length : selectValue;
                }
                // If it doesn't find anything, then clear both fields (used as a last resort).
                else
                {
                    txtScore.Clear();
                    txtScore.SelectionStart = 0;
                }
            }
        }

        // Scroll bar.
        // As well as using the textbox, the scroll bar can be used to enter a value for the user's score.
        // I have no idea why you would want to do this, as I believe it to be an inferior way to add a record but I
        // was asked for it.
        private void vScrollScore_Scroll(object sender, ScrollEventArgs e)
        {
            // The previous score becomes the 'ScrollScore' (an integer).
            _mPreviousScore = vScrollScore.Value;
            // Converts the score back into a string.
            txtScore.Text = vScrollScore.Value.ToString();
        }

        // Saving changes.
        // We need a way to save chnages to the text file.
        private static void SaveToFile()
        {
            // StreamWriter is used to write changes to the variable '_mFileName' (HiScore.txt).
            using (var file = new StreamWriter(_mFileName))
            {
                // A foreach is used to write changes to any new lines.
                // The variable 'line' is equal to an item from the listbox.
                // 'foreach line in the listbox...'
                foreach (var line in listHighScore.Items)
                {
                    // Writes changes.
                    file.WriteLine(line);
                }
            }
        }

        // Quit button.
        // Saves changes and closes the program.
        private void btnQuit_Click(object sender, EventArgs e)
        {
            // 'SaveToFile' is the method I created above this one, it writes changes to _mFileName.
            SaveToFile();
            // 'Close' is a built-in method, it stops and closes the program.
            Close();
        }
    }
}
