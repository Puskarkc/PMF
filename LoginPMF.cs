using cwbx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMF.DAL;
namespace PMF
{
    public partial class LoginPMF : Form
    {
        public LoginPMF()
        {
            InitializeComponent();
           
          
        }
    
        public void getUserClass(string userId, string pwd)
        {
            AS400System system = new AS400System();
            system.Define("MetLife");
            
            DAL.SetData.userName = system.UserID = userId; //asking from user
            DAL.SetData.password = system.Password = pwd;
            system.IPAddress = "10.40.80.20";
            system.Connect(cwbcoServiceEnum.cwbcoServiceRemoteCmd);

            if (system.IsConnected(cwbcoServiceEnum.cwbcoServiceRemoteCmd) == 1)
            {
                DAL.SetData.correctUserName = userId;
                this.Hide();
                frmMain frmMainPmf = new frmMain();
                frmMainPmf.ShowDialog();
                
                // this function is for verifying user Id and password of the system with this program.
            }
        }


        private void passwordKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLoginPMF_Click(this, new EventArgs());
            }

        }

       

       

        private void btnLoginPMF_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBoxUserName.Text.Trim().Length != 0 && txtBoxPassword.Text.Trim().Length != 0)
                {
                    getUserClass(txtBoxUserName.Text, txtBoxPassword.Text);
                    
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

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
        }


    }
}

