using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMF.DAL;
using PMF.BAL;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace PMF
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }
        public System.Windows.Forms.ErrorProvider mobile1ErrorProvider;
        private ErrorProvider landLineErrorProvider;
        private ErrorProvider emailErrorProvider;
        CalculateDate objCalc = new CalculateDate();
        GetDataMSSQLSERVER objGetMSSQL = new GetDataMSSQLSERVER();


        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                ClearAllData();
                GetData objGetBkp = new GetData();

                objGetBkp.getBackupDate();
                lblNA.Visible = false;
                lblPmfLastUpdated.Text = "PMF Last Updated On: " + objGetBkp.lblPMFlastUpdated.ToString();
                lblUserName.Text = "Logged in as :  " + SetData.correctUserName;
            }
            catch { MessageBox.Show("Please create MASTER_PMF folder on your D: drive and paste agy_pmf.mdb file, or Contact IT Department"); }
            txtBoxSearchPolicy.Focus();
            btnViewContactInfo.Enabled = false;
            txtBoxMobile1.Text = null;
            mobile1ErrorProvider = new System.Windows.Forms.ErrorProvider();
            mobile1ErrorProvider.SetIconAlignment(this.txtBoxMobile1, ErrorIconAlignment.MiddleRight);
            mobile1ErrorProvider.SetIconPadding(this.txtBoxMobile1, 3);
            mobile1ErrorProvider.BlinkRate = 1000;


            mobile1ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.txtBoxMobile1.Validated += new System.EventHandler(this.txtBoxMobile1_Validated);
            this.txtBoxLandLine.Validated += new System.EventHandler(txtBoxLandLine_Validated);
            this.txtBoxEmail.Validated += new System.EventHandler(txtBoxEmail_Validated);


            landLineErrorProvider = new ErrorProvider();
            landLineErrorProvider.SetIconAlignment(this.txtBoxLandLine, ErrorIconAlignment.MiddleRight);
            landLineErrorProvider.SetIconPadding(this.txtBoxLandLine, 3);
            landLineErrorProvider.BlinkRate = 2000;
            landLineErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            emailErrorProvider = new ErrorProvider();
            emailErrorProvider.SetIconAlignment(this.txtBoxEmail, ErrorIconAlignment.MiddleRight);
            emailErrorProvider.SetIconPadding(this.txtBoxEmail, 3);
            emailErrorProvider.BlinkRate = 2000;
            emailErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
        private void txtSearchPolicyNumber_KeyDown(object sender, KeyEventArgs e)
        {
            mobile1ErrorProvider.Clear(); emailErrorProvider.Clear(); landLineErrorProvider.Clear();// this is for test 
            if (e.KeyCode == Keys.Enter)
            {
                btnGo_Click(this, new EventArgs());
            }
        }
        private void txtBoxMobile1_Validated(object sender, System.EventArgs e)
        {
            if (!IsMobile1Valid())
            {
                txtBoxMobile1.Text = null;
                mobile1ErrorProvider.SetError(this.txtBoxMobile1, "No Mobile number found");
                txtBoxMobile1.BackColor = Color.Tomato;

            }
            else
            {
                mobile1ErrorProvider.SetError(this.txtBoxMobile1, String.Empty);
                txtBoxMobile1.BackColor = Color.White;
            }
        }

        private void txtBoxLandLine_Validated(object sender, System.EventArgs e)
        {
            if (!IsLandLineValid())
            {
                txtBoxLandLine.Text = null;
                landLineErrorProvider.SetError(this.txtBoxLandLine, "No Land line number found");
                txtBoxLandLine.BackColor = Color.Tomato;

            }
            else
            {
                landLineErrorProvider.SetError(this.txtBoxLandLine, String.Empty);
                txtBoxLandLine.BackColor = Color.White;
            }
        }
        private void txtBoxEmail_Validated(object sender, System.EventArgs e)
        {
            if (!IsEmailValid())
            {
                txtBoxEmail.Text = null;
                emailErrorProvider.SetError(this.txtBoxEmail, "No email address number found");
                txtBoxEmail.BackColor = Color.Tomato;
            }
            else
            {
                emailErrorProvider.SetError(this.txtBoxEmail, String.Empty);
                txtBoxEmail.BackColor = Color.White;
            }
        }

        public bool IsMobile1Valid()
        {
            return (txtBoxMobile1.Text.Length > 0 && txtBoxMobile1.Text.Trim().Length > 0);
            //  return (SetData.mobile1.Length > 0 && SetData.mobile1.Trim().Length > 0);
        }
        //public bool IsMobile2Valid()
        //{
        //    return (txtBoxMobile2.Text.Length > 0 && txtBoxMobile2.Text.Trim().Length > 0);
        //}
        public bool IsLandLineValid()
        {
            return (txtBoxLandLine.Text.Length > 0 && txtBoxLandLine.Text.Trim().Length > 0);
        }
        public bool IsEmailValid()
        {
            return (txtBoxEmail.Text.Length > 0 && txtBoxEmail.Text.Trim().Length > 0);
        }

        public bool IsSearchBoxEmpty()
        {
            return (txtBoxSearchPolicy.Text.Length > 0);
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btnContactUpdate_Click(object sender, EventArgs e)
        {

            mobile1ErrorProvider.Clear(); emailErrorProvider.Clear(); landLineErrorProvider.Clear();// this is for test of removing blinking dots

            if (DAL.SetData.correctUserName == null)
            {
                LoginToUpdate frmLogin = new LoginToUpdate();
                frmLogin.ShowDialog();
            }
            else
            {

                //   if (txtBoxSearchPolicy.Text.Trim().Length != 0 && txtBoxSearchPolicy.Text.Length != 0 && lblPolicyNuber.Text.Length != 0)
                if (lblPolicyNuber.Text.Length != 0 && lblPolicyNuber.Text.Trim().Length != 0)
                {
                    SetData.mobile1 = txtBoxMobile1.Text;
                    // objGetAdd.mobile2 = txtBoxMobile2.Text;
                    SetData.landLine = txtBoxLandLine.Text;
                    SetData.email = txtBoxEmail.Text;
                    SetData.PolicyTempStore = lblPolicyNuber.Text.Trim();
                    frmUpdateContact frm = new frmUpdateContact();
                    frm.ShowDialog();
                    txtBoxMobile1.Text = SetData.mobile1;

                    txtBoxLandLine.Text = SetData.landLine;
                    txtBoxEmail.Text = SetData.email;

                }
                else { MessageBox.Show("Please Specify the Poilcy number of which you want to Update Contact Information", "Alert"); }
            }
        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            lblErrorMsSql.Text = lblErrorSystem.Text = lblCurrentPremiumDue.Text = lblOverDuePremium.Text = lblDispatched.Text = "";
            lblNA.Visible = false;
           // lblDispatched.Visible = false;
            SetData.oldLandline = " "; SetData.oldEmail = " "; SetData.oldMobile = " ";
            lblRatedNotRated.Text = lblUnderWritingApproved.Text = btnCalculate.Text = lblTotalPremium.Text = "";
            objGetMSSQL.PartialMaturityDate = objGetMSSQL.AmountOfPartialMaturity = lblDatePartialMaturity.Text = lblAmountPartialMaturity.Text = null;
            if (!IsSearchBoxEmpty())
            {

                txtBoxSearchPolicy.BackColor = Color.Peru;
                MessageBox.Show("Please Enter Policy Number", "Policy Not Found");
                txtBoxSearchPolicy.Focus();
                txtBoxSearchPolicy.BackColor = Color.White;
                btnViewContactInfo.Enabled = false;

            }
            else
            {
                btnViewContactInfo.Enabled = true;
                GetData objGet = new GetData();
                objGet.getData(txtBoxSearchPolicy.Text);



                GetDataAS400 objGetAs400 = new GetDataAS400();
                objGetAs400.getDataAS400(txtBoxSearchPolicy.Text);
                try { lblPolicyNuber.Text = objGet.lblPolicyNumber.ToString(); }
                catch
                {
                    MessageBox.Show("Incorrect Policy Number");
                    ClearAllData();
                    txtBoxSearchPolicy.Focus();
                    return;
                }
                try
                {


                    lblPolicyNuber.Text = objGet.lblPolicyNumber.ToString();

                    lblInsuredName.Text = objGet.lblInsuredName.ToString();
                    lblIssuedDatePolicy.Text = objGet.lblIssuedDatePolicy.ToString();
                    lblStatusPolicy.Text = objGet.lblStatusPolicy.ToString();


                    if (lblStatusPolicy.Text == "20")
                    {
                        lblStatusPolicy.ForeColor = Color.White;
                        lblStatusPolicy.BackColor = Color.Green;
                    }
                    else
                    {
                        lblStatusPolicy.BackColor = Color.Red;
                        lblStatusPolicy.ForeColor = Color.White;
                    }
                    SetData.CurrentPremiumDue = lblCurrentPremiumDue.Text = string.Format("{0:#,#.}", Convert.ToDouble(objGet.lblModalPremium));
                    lblModalPremium.Text = string.Format("{0:#,#.}", Convert.ToDouble(objGet.lblModalPremium));

                    double mod_Prem = Convert.ToDouble(objGet.lblModalPremium.ToString());

                    string toSplit = lblDueDate.Text = objGet.lblDueDate.ToString();
                    string[] splitDate = toSplit.Split('/');
                    int dd = Convert.ToInt32(splitDate[0]); // splitting sstring and keeping them in integer format
                    int mm = Convert.ToInt32(splitDate[1]);
                    int yy = Convert.ToInt32(splitDate[2]);
                    int mod = (Convert.ToInt32(objGet.lblMode));

                    lblNextDueDate.Text = objCalc.calcDate(dd, mm, yy, mod); // dd/mm/yy/mode from Calculate date Class
                    lblDaysEllapsedPolicy.Text = objCalc.DateDifference(dd, mm, 2000 + yy).ToString() + "  Days";
                    if (Convert.ToInt32(objCalc.DateDifference(dd, mm, 2000 + yy)) > 91)
                    {
                        lblDaysEllapsedPolicy.BackColor = Color.Red;
                        lblDaysEllapsedPolicy.ForeColor = Color.White;
                    }
                    else
                    {
                        lblDaysEllapsedPolicy.BackColor = Color.White;
                        lblDaysEllapsedPolicy.ForeColor = Color.Black;
                    }
                    double days_comp = Convert.ToDouble(objCalc.DateDifference(dd, mm, 2000 + yy).ToString());

                    lblAgentCode.Text = objGet.lblAgentCode.ToString();
                    lblMode.Text = objGet.lblMode.ToString();
                    lblType1.Text = objGet.lblType1.ToString();
                    lblAmount1.Text = string.Format("{0:#,#.}", Convert.ToDouble(objGet.lblAmount1));
                    lblDate1.Text = objGet.lblDate1.ToString();

                    lblPremAmt1.Text = string.Format("{0:#,#.}", Convert.ToDouble(objGet.lblPremAmt1));
                    lblDueDate1.Text = objGet.lblDueDate1.ToString();
                    lbPaidDate1.Text = objGet.lbPaidDate1.ToString();

                    lblPremAmt2.Text = string.Format("{0:#,#.}", Convert.ToDouble(objGet.lblPremAmt2));
                    lblDueDate2.Text = objGet.lblDueDate2.ToString();
                    lblPaidDate2.Text = objGet.lblPaidDate2.ToString();
                    lblPremAmt3.Text = string.Format("{0:#,#.}", Convert.ToDouble(objGet.lblPremAmt3));
                    lbDueDate3.Text = objGet.lbDueDate3.ToString();
                    lblPadiDate3.Text = objGet.lblPadiDate3.ToString();

                    lblOwnersName.Text = objGet.lblOwnersName.ToString();
                    lblOwnersCode.Text = objGet.lblOwnersCode.ToString();
                    lblAddress1.Text = objGet.lblAddress1.ToString();
                    lblAddress2.Text = objGet.lblAddress2.ToString();
                    lblPlan.Text = objGet.lblPlan.ToString();
                    lblCoverageAmt.Text = string.Format("{0:#,#.}", Convert.ToDouble(objGet.lblCoverageAmt));
                    lblSex.Text = objGet.lblSex.ToString();
                    lblBirthDate.Text = objGet.lblBirthDate.ToString();
                    lblAge.Text = objGet.lblAge.ToString();

                    lblAutomaticPrmloan.Text = objGet.lblAutomaticPrmloan.ToString();
                    if (lblAutomaticPrmloan.Text == "Y" || lblAutomaticPrmloan.Text == "y")
                    {
                       lblAPLCount.BackColor = lblAutomaticPrmloan.BackColor = Color.Red;
                       lblAPLCount.ForeColor = lblAutomaticPrmloan.ForeColor = Color.White;
                    }
                    else
                    {
                        lblAPLCount.BackColor = lblAutomaticPrmloan.BackColor = Color.White;
                        lblAPLCount.ForeColor = lblAutomaticPrmloan.ForeColor = Color.Black;
                    }
                    lblAPLCount.Text = objGet.lblAPLCount.ToString();
                    lblLoanType.Text = objGet.lblLoanType.ToString();
                    lblLoanPrincipleamt.Text = objGet.lblLoanPrincipleamt.ToString();
                    lblLoanDate.Text = objGet.lblLoanDate.ToString();
                    lblRatedNotRated.Text = objGet.lblRatedNotRated.ToString();
                    lblUnderWritingApproved.Text = objGet.lblUnderWritingApproved.ToString();
                    LateFeeCalculation objLateFee = new LateFeeCalculation();



                    double int_Rate = 0.12;
                    double tot_interest = 0;
                    double tot_amount = 0;
                    int limit_days = 90;

                    int status = Convert.ToInt32(lblStatusPolicy.Text);

                    DateTime due_date = new DateTime(2000 + yy, mm, dd);
                    if ((status == 20 || status == 42 || status == 45) && (days_comp > 90))
                    {

                        do
                        {
                            tot_interest = tot_interest + (mod_Prem * Math.Pow((1 + int_Rate), (days_comp / 365)) - mod_Prem);

                            due_date = due_date.AddMonths(mod);
                            days_comp = DateTime.Now.Subtract(due_date).TotalDays;
                            tot_amount = tot_amount + mod_Prem;
                        } while (days_comp > limit_days);



                        if (days_comp > 0)
                        {
                            tot_amount = tot_amount + mod_Prem;            //'this statement is for the last premiun due
                        }


                        SetData.LateFee = string.Format("{0:#,#.}", tot_interest);
                        btnCalculate.Text = string.Format("{0:#,#.}", tot_interest);

                        double totalPremium = tot_amount + tot_interest;
                        SetData.TotalAmountDue = string.Format("{0:#,#.}", totalPremium);
                        lblTotalPremium.Text = string.Format("{0:#,#.}", totalPremium);
                        double amount = Convert.ToDouble(objGet.lblAmount1);

                        double payableAmount = totalPremium - amount;
                        SetData.AmountInDeposit = string.Format("{0:#,#.}", amount);
                        SetData.NetPayableAmount = string.Format("{0:#,#.}", payableAmount); // subtracting amount in Suspence group
                        SetData.Overdueprem = lblOverDuePremium.Text= string.Format("{0:#,#.}", tot_amount);



                    }
                    ////for the case of the mobile number.
                    //from as400
                    if (objGetAs400.mobile1.Length > 0 && objGetAs400.mobile1.Trim().Length > 0)
                    {
                        txtBoxMobile1.Text = objGetAs400.mobile1;
                        
                        
                    }
                    else { txtBoxMobile1.Text = null; }
                    if (objGetAs400.landLine.Length > 0 && objGetAs400.landLine.Trim().Length > 0)
                    {
                        txtBoxLandLine.Text = objGetAs400.landLine;
                      
                        
                    }
                    else { txtBoxLandLine.Text = null; }
                    if (objGetAs400.email.Length > 0 && objGetAs400.email.Trim().Length > 0)
                    {
                        txtBoxEmail.Text = objGetAs400.email;
                      
                     
                    }
                    else { txtBoxEmail.Text = null; }
                    SetData.oldEmail = objGetAs400.email;
                    SetData.oldLandline = objGetAs400.landLine;
                    SetData.oldMobile = objGetAs400.mobile1;
                    //to As400
                    objGetAs400.mobile1 = txtBoxMobile1.Text;
                    // mobile2 = txtBoxMobile2.Text;
                    objGetAs400.landLine = txtBoxLandLine.Text;
                    objGetAs400.email = txtBoxEmail.Text;

                    txtBoxSearchPolicy.Text = "";

                }
                catch
                {


                    //  MessageBox.Show("Incorrect Policy Number", "ALERT!!!!");
                    lblErrorSystem.Text = objGetAs400.errorSystem;

                    return; // this is for test purpose


                }

                if (!IsMobile1Valid())
                {
                    mobile1ErrorProvider.SetError(this.txtBoxMobile1, "No Mobile number found");
                    txtBoxMobile1.BackColor = Color.Tomato;


                }
                else { txtBoxMobile1.BackColor = Color.White; }
                if (!IsLandLineValid())
                {
                    landLineErrorProvider.SetError(this.txtBoxLandLine, "No landline Found");
                    txtBoxLandLine.BackColor = Color.Tomato;

                }
                else { txtBoxLandLine.BackColor = Color.White; }

                if (!IsEmailValid())
                {
                    emailErrorProvider.SetError(this.txtBoxEmail, "No Email Found");
                    txtBoxEmail.BackColor = Color.Tomato;
                }
                else { txtBoxLandLine.BackColor = Color.White; }


            }

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            ReportForm frmReport = new ReportForm();
            frmReport.ShowDialog();

        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {

            ReportForm frmReport = new ReportForm();
            frmReport.ShowDialog();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearAllData();
            txtBoxSearchPolicy.Focus();
        }

        public void ClearAllData()
        {
            lblPolicyNuber.Text = lblInsuredName.Text = lblIssuedDatePolicy.Text = lblStatusPolicy.Text = lblModalPremium.Text = lblNextDueDate.Text = lblDaysEllapsedPolicy.Text =
            lblAgentCode.Text = lblMode.Text = lblType1.Text = lblAmount1.Text = lblDate1.Text = lblPremAmt1.Text = lblDueDate1.Text = lbPaidDate1.Text = lblPremAmt2.Text = lblDueDate2.Text =
            lblPaidDate2.Text = lblPremAmt3.Text = lbDueDate3.Text = lblPadiDate3.Text = lblOwnersName.Text = lblOwnersCode.Text = lblAddress1.Text = lblAddress2.Text = lblPlan.Text = lblCoverageAmt.Text =
            lblSex.Text = lblBirthDate.Text = lblAge.Text = lblAutomaticPrmloan.Text = lblAPLCount.Text = lblLoanType.Text = lblLoanPrincipleamt.Text = lblLoanDate.Text = lblRatedNotRated.Text = lblUnderWritingApproved.Text =
            btnCalculate.Text = lblTotalPremium.Text = lblDueDate.Text = txtBoxEmail.Text = txtBoxMobile1.Text = txtBoxSearchPolicy.Text = txtBoxLandLine.Text = lblDatePartialMaturity.Text =
            lblAmountPartialMaturity.Text = lblDispatched.Text = lblCurrentPremiumDue.Text = lblOverDuePremium.Text= "";
            lblDateDummy.Visible = true;
            lblAmountDummy.Visible = true;
            lblNA.Visible = false;
         
            txtBoxLandLine.BackColor = txtBoxMobile1.BackColor = txtBoxEmail.BackColor = Color.White;
        }




        private void MobileClick(object sender, EventArgs e)
        {
            txtBoxMobile1.BackColor = Color.White;
        }

        private void landLineClick(object sender, EventArgs e)
        {
            txtBoxLandLine.BackColor = Color.White;
        }

        private void txtBoxEmail_Click(object sender, EventArgs e)
        {
            txtBoxEmail.BackColor = Color.White;
        }

        private void btnViewPM_Click(object sender, EventArgs e)
        {
            try
            {
                objGetMSSQL.getDataMSSQL(lblPolicyNuber.Text);
                if (Convert.ToInt32(objGetMSSQL.ChequeDispatched) == 0)
                {
                    lblDispatched.Text = "";
                    lblDateDummy.Visible = true;
                    lblAmountDummy.Visible = true;
                    lblDatePartialMaturity.Text = objGetMSSQL.PartialMaturityDate;
                    lblAmountPartialMaturity.Text = objGetMSSQL.AmountOfPartialMaturity;
                    if (Convert.ToInt32(objGetMSSQL.AmountOfPartialMaturity) == 0)
                    {
                        lblNA.Visible = true;
                        lblNA.Text = "* No outstanding cheques";
                    }
                }
                else if (Convert.ToInt32(objGetMSSQL.ChequeDispatched) == 1)
                {
                    lblDispatched.Text = "*  Dispatched ";
                    lblDateDummy.Visible = false;
                    lblAmountDummy.Visible = false;
                    lblDatePartialMaturity.Text = lblAmountPartialMaturity.Text = null;
                }

                else
                {
                    lblNA.Visible = true;
                    lblNA.Text = "* N/A";
                }
            }
            catch
            {

                lblErrorMsSql.Text = objGetMSSQL.errorSQl;
                return;
            }


        }



    }
}
