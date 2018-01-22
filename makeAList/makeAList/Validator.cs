using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace makeAList
{
    // repository for validating methods
    public static class Validator
    {
        // check if text box not empty
        public static bool IsPresent(TextBox tb, string name)
        {
            bool valid = true; // innocent until proven guilty
            if(tb.Text == "") // bad
            {
                valid = false;
                MessageBox.Show(name + " is required");
                tb.Focus();
            }
            return valid;
        }

        // check if textbox has int value in it
        public static bool IsInt32(TextBox tb, string name)
        {
            bool valid = true; // presumme valid
            int value;
            if(!Int32.TryParse(tb.Text, out value)) // bad news
            {
                valid = false;
                MessageBox.Show(name + " must be  a whole number");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        // check if textbox has non-negative int value
        public static bool IsNonNegativeInt(TextBox tb, string name)
        {
            bool valid = true;
            int value;

            if (!Int32.TryParse(tb.Text, out value)) // bad news
            {
                valid = false;
                MessageBox.Show(name + " must be  a whole number");
                tb.SelectAll();
                tb.Focus();
            }
            else if (value < 0) // bad
            {
                valid = false;
                MessageBox.Show(name + " must be a equal to or greater than zero");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        // check if textbox has double value in it
        public static bool IsDouble(TextBox tb, string name)
        {
            bool valid = true; // presumme valid
            double value;
            if (!Double.TryParse(tb.Text, out value)) // bad news
            {
                valid = false;
                MessageBox.Show(name + " must be a number");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        // check if textbox has non-negative double value
        public static bool IsNonNegativeDouble(TextBox tb, string name)
        {
            bool valid = true;
            double value;

            if (!Double.TryParse(tb.Text, out value)) // bad news
            {
                valid = false;
                MessageBox.Show(name + " is required. If free put 0.");
                tb.SelectAll();
                tb.Focus();
            }
            else if (value < 0) // bad
            {
                valid = false;
                MessageBox.Show(name + " must be a equal to or greater than zero");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }
    }
}
