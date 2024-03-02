using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSMap
{
    public partial class RefreshForm : Form
    {
        private User user;
        public RefreshForm(User u)
        {
            InitializeComponent();
            user = u;
        }

        private void KeyPressDown(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            int refreshValue;
            string text = refreshValueBox.Text;
            if (int.TryParse(text, out refreshValue))
            {
                if (refreshValue > 1)
                {
                    user.SetRefresh(refreshValue);
                    Close();
                }
                else
                {
                    MessageBox.Show("Error: Please enter a valid number", "Int parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Error: Please enter a valid number", "Int parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
