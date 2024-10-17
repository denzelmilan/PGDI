using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {

        public string psw = "Password";
        public string pswmsg = "we wont guess the password";
        public string usr = "Username";
        public string usrmsg = "are we supposed to guess your username '-' ?";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if ((userBox.Text == usr) || (userBox.Text == usrmsg))
            {

                userBox.Text = string.Empty;
                userBox.ForeColor = Color.Black;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (userBox.Text == "")
            {

                userBox.Text = usrmsg;
                userBox.ForeColor = Color.Silver;

            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            while (((userBox.Text == usr) || (userBox.Text == usrmsg)) &&((passwordbox.Text == psw) || (passwordbox.Text == pswmsg)))
            {
                runAway();
            }
        }


        private void runAway()
        {

            button1.Text = "WAIT";
            button1.BackColor = Color.Red;
            Random rnd = new Random();

            int formWdt = this.ClientSize.Width;
            int formhgt = this.ClientSize.Height;

            int newX = rnd.Next(0, formWdt - button1.Width);
            int newY = rnd.Next(0, formhgt - button1.Height);

            button1.Location = new Point(newX, newY);
            button1.Text = "LOGIN";
            button1.BackColor = Color.Transparent;

        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            int deltaX = Math.Abs(e.X - (button1.Location.X + button1.Width));
            int deltaY = Math.Abs(e.Y - (button1.Location.Y + button1.Height));

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            int proximityTHRSHLD = 200;

            if (distance > proximityTHRSHLD)
            {

                runAway();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void passwordbox_Enter(object sender, EventArgs e)
        {
            if ((passwordbox.Text == psw) || (passwordbox.Text == pswmsg))
            {

                passwordbox.Text = string.Empty;
                passwordbox.ForeColor = Color.Black;

            }
        }

        private void passwordbox_Leave(object sender, EventArgs e)
        {
            if (passwordbox.Text == "") { 
                passwordbox.Text = pswmsg;
                passwordbox.ForeColor= Color.Silver;
            }
        }
    }
}
