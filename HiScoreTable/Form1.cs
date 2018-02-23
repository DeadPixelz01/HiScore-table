using System;
using System.IO;
using System.Windows.Forms;

namespace HiScoreTable
{
    public partial class FrmHiScore : Form
    {
        private static int _mPreviousScore;
        private static string _mFileName;

        public FrmHiScore()
        {
            InitializeComponent();

            _mFileName = "HiScore.txt";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            listHighScore.Items.Add(txtName.Text + "," + txtScore.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var index = listHighScore.SelectedIndex;
            listHighScore.Items.RemoveAt(index);
        }

        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            var selectValue = txtScore.SelectionStart;

            if (int.TryParse(txtScore.Text, out var scoreValue))
            {
                if (scoreValue > 9999) scoreValue = _mPreviousScore;
                _mPreviousScore = scoreValue;
                txtScore.Text = scoreValue.ToString();
                txtScore.SelectionStart = txtScore.Text.Length >= selectValue ? txtScore.Text.Length : selectValue;
            }
            else
            {
                if (_mPreviousScore != 0 && txtScore.Text != "")
                {
                    txtScore.Text = _mPreviousScore.ToString();
                    txtScore.SelectionStart =
                        txtScore.Text.Length >= selectValue ? txtScore.Text.Length : selectValue;
                }
                else
                {
                    txtScore.Clear();
                    txtScore.SelectionStart = 0;
                }
            }
        }

        private void vScrollScore_Scroll(object sender, ScrollEventArgs e)
        {
            _mPreviousScore = vScrollScore.Value;
            txtScore.Text = vScrollScore.Value.ToString();
        }

        private static void SaveToFile()
        {
            using (var file = new StreamWriter(_mFileName))
            {
                foreach (var line in listHighScore.Items)
                {
                    file.WriteLine(line);
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            SaveToFile();
            Close();
        }

        private void FrmHiScore_Load(object sender, EventArgs e)
        {
            using (var file = new StreamReader(_mFileName))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    listHighScore.Items.Add(line);
                }
                file.Close();
            }
        }
    }
}
