// Author: Alexander Smith
// Date: 2/7/2018
// Description: A small C# script that utilises a GUI to calculate the cost of carpet based off of the area required.

// From my understanding, these are like the C# equivalent to Python imports.
// I'd like to imagine this where developers could import/use 3rd party packages.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CarpetOrders
{
    public partial class FrmCarpetOrders : Form
    {
        public FrmCarpetOrders()
        {
            InitializeComponent();

            // Date.
            // The following line auto loads the system's date.
            // See line 25 ("dd/MM/yyyy") to change the format.
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Setting to 'Read Only'.
            // The following just sets the calculated results to 'Read Only'. This is done so that the user
            // can't change the results by hand. I wish there was a way to implement this later on in the script
            // (between lines 104 and 108, when I make give the textboxes vaules).
            // -- Side Note --
            // I should probably stop referencing lines in my internal documentation because this c# script is
            // always under going maintenance :p.
            txtDate.ReadOnly = true;
            txtCalName.ReadOnly = true;
            txtArea.ReadOnly = true;
            txtCost.ReadOnly = true;
            txtDiscount.ReadOnly = true;
            txtTotalCost.ReadOnly = true;
        }

        // Calculation button.
        // This button calculates and outputs values.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Defining variables and data types.
            // Linking them back to the form ('Form1.Designer.cs').
            // 'const' is used here because strInvalidSelection's string value will never change.
            const string strInvalidSelection = "Invalid selection! Choose between Quality No. 1, 2, 3 or 4"; // String.
            var strName = txtName.Text; // String (This was never used, so why did we ask for it!? I fixed this :p).
            var intQualityNo = int.Parse(txtQuality.Text); // Integer.
            decimal decRWidth = decimal.Parse(txtWidth.Text), decRLength = decimal.Parse(txtLength.Text); // Decimal.
            var decRArea = decRWidth * decRLength; // Calculating the room's area (Lenght * Width = Area).
            var boolTradeDiscount = chkDiscount.Checked; // Boolean.

            // Using Dictionaries and calculating Cost.
            // Since the user has to choose between quality 1-4, the variable 'intQualityNo' is subbed into the
            // dictionary. For example if the user entered '1', the variable cost would equal their area multiplied by
            // 100.
            // -- Side note --
            // This was original a switch but as of 2/18/2018, I've turned it into a dictionary. Look at how much
            // neater it is!
            var qualityList = new Dictionary<int, int> {{1, 100}, {2, 70}, {3, 45}, {4, 30}};

            if (qualityList.ContainsKey(intQualityNo))
            {
                var decCost = qualityList[intQualityNo] * decRArea; // Decimal.

                // Calculating a discount.
                // If the user asked for a Trade discount, then...
                decimal decDiscount; // Decimal.
                if (boolTradeDiscount)
                {
                    // Discount is equal to the cost, multiplied by 0.1
                    decDiscount = decCost * Convert.ToDecimal(0.1);
                }
                // If they didn't, then...
                else
                {
                    // The user is given a discount of $0.
                    decDiscount = 0;
                }

                // To calculate the total cost, this line subtracts the discount from the cost.
                var decTotalCost = decCost - decDiscount;

                // Formating.
                // I had to introduce these new variables so that they can be formated into local currency.
                var strCost = $"{decCost:C}";
                var strDiscount = $"{decDiscount:C}";
                var strTotalCost = $"{decTotalCost:C}";
                // Colors.
                // I know it's spelt colour, but most programming languages use 'American English' isn't of
                // 'British English'. So as soon as I start programming, I throw all my spelling out the
                // door...
                txtArea.BackColor = Color.LightYellow;
                txtCost.BackColor = Color.LightGreen;
                txtTotalCost.BackColor = Color.LightGreen;
                txtDiscount.BackColor = Color.LightCoral;

                // Converting back to strings.
                // A lot of the variables have the data type of integer and decimal,
                // so they need to be converted back into strings so that they can be displayed within a textbox.
                txtCalName.Text = strName;
                txtArea.Text = decRArea.ToString(CultureInfo.CurrentCulture);
                txtCost.Text = strCost.ToString(CultureInfo.CurrentCulture);
                txtDiscount.Text = strDiscount.ToString(CultureInfo.CurrentCulture);
                txtTotalCost.Text = strTotalCost.ToString(CultureInfo.CurrentCulture);
            }
            else
            {
                Console.WriteLine(strInvalidSelection);
            }
        }

        // Exit button.
        // When 'btnExit' is clicked, it runs the command 'Close();'.
        // This will just stop and close the program, self explanatory.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Resetting and clearing fields.
        // The following loop clears every textbox within the form.
        // It's now a loop!
        private void btnReset_Click(object sender, EventArgs e)
        {
            void FuncClear(IEnumerable controls)
            {
                foreach (Control clearControl in controls)
                    if (clearControl is TextBox)
                        (clearControl as TextBox).Clear();
                    else
                    {
                        FuncClear(clearControl.Controls);
                    }
            }

            FuncClear(Controls);
        }
    }
}