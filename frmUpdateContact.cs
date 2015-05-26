using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMF.BAL;
using PMF.DAL;
using System.Text.RegularExpressions;
namespace PMF
{
    public partial class frmUpdateContact : Form
    {
        string StorePolicy = SetData.PolicyTempStore;
        public frmUpdateContact()
        {
            InitializeComponent();

         txtBoxMobile1Dialog.Text = SetData.mobile1;

          txtBoxLandLineDialog.Text = SetData.landLine;
        txtBoxEmailDialog.Text = SetData.email;
   }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateDialog_Click(object sender, EventArgs e)
        {
            SetData.mobile1 = txtBoxMobile1Dialog.Text.Trim();
            SetData.landLine = txtBoxLandLineDialog.Text.Trim();
            SetData.email = txtBoxEmailDialog.Text.Trim();

            SetData.newMobile1 = txtBoxMobile1Dialog.Text.Trim();
            SetData.newLandline = txtBoxLandLineDialog.Text.Trim();
            SetData.newEmail = txtBoxEmailDialog.Text.Trim();

            bool isEmailCorrect = Regex.IsMatch(txtBoxEmailDialog.Text.Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
            bool isMobCorrect = Regex.IsMatch(txtBoxMobile1Dialog.Text.Trim(), @"^[0-9]{1,15}$");// regular expression that checks, 15 not more than 15 digit, 009779841890989
            bool isLandLineCorrect = Regex.IsMatch(txtBoxLandLineDialog.Text.Trim(), @"^[0-9]{1,15}$");
            if (
                (isEmailCorrect == true || txtBoxEmailDialog.Text.Trim().Length == 0)
                && (isMobCorrect == true || txtBoxMobile1Dialog.Text.Trim().Length == 0)
                && (isLandLineCorrect == true || txtBoxLandLineDialog.Text.Trim().Length == 0)
                )
            {
                InsertContactToAS400 obj = new InsertContactToAS400();
                obj.InsertToAS400(StorePolicy);

                updateUserDetails obj2 = new updateUserDetails();
                obj2.AS400UpdatedContact(StorePolicy);
 
                PMF.frmMain frm = new frmMain();
                frm.txtBoxMobile1.Text = SetData.mobile1;
                frm.txtBoxLandLine.Text = SetData.landLine;
                frm.txtBoxEmail.Text = SetData.email;
                this.Close();
            }
            else { MessageBox.Show("Please Note: " + System.Environment.NewLine + "Phone numbers are always numeric characters. eg: 9876543210" + System.Environment.NewLine +  System.Environment.NewLine + "Email Should be in standard format. eg: correctemailformat@example.com", "Incorrect Values"); }

           
        }
      
    }
}
