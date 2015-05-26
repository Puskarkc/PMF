using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cwbx; // dll file used to  connect IBM AS400
namespace PMF
{
    public partial class LoginToUpdate : Form
    {
        public LoginToUpdate()
        {
            InitializeComponent();
     
        }

        public void getUserClass(string userId, string pwd)
        {
            AS400System system = new AS400System();
            system.Define("MetLife");
            //try
            //{
            //    system.VerifyUserIDPassword(userId, pwd);
            //    MessageBox.Show("Login Successful");
            //}
            //catch { MessageBox.Show("wrong password"); }
            //  system.Define("AS400");
            DAL.SetData.userName = system.UserID = userId; //asking from user
            DAL.SetData.password = system.Password = pwd;
            system.IPAddress = "10.40.80.20";
            system.Connect(cwbcoServiceEnum.cwbcoServiceRemoteCmd);

            if (system.IsConnected(cwbcoServiceEnum.cwbcoServiceRemoteCmd) == 1)
            {
                DAL.SetData.correctUserName = userId; 

                //frmUpdateContact frm = new frmUpdateContact();
                //frm.ShowDialog();
                this.Hide();
                //  system.Disconnect(cwbcoServiceEnum.cwbcoServiceAll); // disconnect from system
                // this function is for verifying user Id and password of the system with this program.
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
        }

        private void passwordKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click_1(this, new EventArgs());
            }

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtBoxUserName.Text.Trim().Length != 0 && txtBoxPassword.Text.Trim().Length != 0)
                {
                    getUserClass(txtBoxUserName.Text, txtBoxPassword.Text);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("You must Specify your User Name and Password.", "Error!!!");
                    this.txtBoxUserName.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Please type your correct password", "Worng Password");
                this.txtBoxUserName.Text = "";
                this.txtBoxPassword.Text = "";
                this.txtBoxUserName.Focus();
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
