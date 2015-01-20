using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyCode
{
    public partial class Form1 : Form
    {
        private DateTime? _timeValue = null;

        public Form1()
        {
            InitializeComponent();
            DoubleKeyWarning.Text = String.Empty;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (char.IsLetter(e.KeyChar))
            {
                // char is letter
            }
            else if (char.IsDigit(e.KeyChar))
            {
                // char is digit
            }
            else
            {
                // char is neither letter or digit.
                // there are more methods you can use to determine the
                // type of char, e.g. char.IsSymbol
            }
        }

        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (_timeValue == null)
            {
                _timeValue = DateTime.Now;
            }
            else
            {
                TimeSpan? val =  DateTime.Now - _timeValue;
                _timeValue = DateTime.Now;
                if (val.Value.TotalSeconds > 1)
                {
                    DoubleKeyWarning.Text = String.Empty;
                }
                else
                {
                    DoubleKeyWarning.Text = "Double Key hit prev key = " + KeyCodeStatus.Text;
                }
            }
            // Determine whether the keystroke is a number from the top of the keyboard. 
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                KeyCodeStatus.Text = e.KeyCode.ToString();
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                KeyCodeStatus.Text = e.KeyCode.ToString();
            }
            else if (e.KeyCode == Keys.Back)
            {
                KeyCodeStatus.Text = "Back key pressed";
            } else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                KeyCodeStatus.Text = e.KeyCode.ToString();
            }
            else
            {
                KeyCodeStatus.Text = e.KeyCode.ToString();
            }

            //If shift key was pressed, it's not a number. 
            if (Control.ModifierKeys == Keys.Shift)
            {
                KeyCodeStatus.Text = KeyCodeStatus.Text + "Shift Key is pressed";
            }
        }
    }
}
