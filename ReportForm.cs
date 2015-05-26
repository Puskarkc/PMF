using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PMF.DAL;
namespace PMF
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {

            InitializeComponent();
        }

        public void crystalReportViewer1_Load(object sender, EventArgs e)
        {


        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

            try
            {
                GetData objGet = new GetData();
                DataSet1 ds = new DataSet1();
                DataTable t = ds.Tables.Add("Items");

                t.Columns.Add("Name", Type.GetType("System.String"));
                t.Columns.Add("PolicyNumber", Type.GetType("System.String"));
                t.Columns.Add("PolicyMode", Type.GetType("System.String"));
                t.Columns.Add("CurrentPremiumDue", Type.GetType("System.String"));
                t.Columns.Add("Overdueprem", Type.GetType("System.String"));
                t.Columns.Add("LateFee", Type.GetType("System.String"));
                t.Columns.Add("TotalAmountDue", Type.GetType("System.String"));
                t.Columns.Add("AmountInDeposit", Type.GetType("System.String"));
                t.Columns.Add("NetPayableAmount", Type.GetType("System.String"));

                DataRow r;


                r = t.NewRow();

                r["Name"] = SetData.lblInsuredName.ToString();
                r["PolicyNumber"] = SetData.lblPolicyNumber.ToString();

                int polMode = Convert.ToInt32(SetData.lblMode);
                string policyMode;
                if (polMode == 3)
                {
                    policyMode = "Quarterly";
                }
                else if (polMode == 6) { policyMode = "Semi-Annual"; }
                else { policyMode = "Annual"; }
                r["PolicyMode"] = policyMode;

                r["CurrentPremiumDue"] = SetData.CurrentPremiumDue.ToString();
                r["Overdueprem"] = SetData.Overdueprem.ToString();
                r["LateFee"] = SetData.LateFee.ToString();
                r["TotalAmountDue"] = SetData.TotalAmountDue.ToString();
                r["AmountInDeposit"] = SetData.AmountInDeposit.ToString();
                r["NetPayableAmount"] = SetData.NetPayableAmount.ToString();


                t.Rows.Add(r);


                CrystalReport2 objRpt = new CrystalReport2();
                objRpt.SetDataSource(ds.Tables[1]);
                objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4; // setting the paper size,,
                objRpt.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0));
                crystalReportViewer1.ReportSource = objRpt;

                crystalReportViewer1.Refresh();
            }
            catch
            {
                MessageBox.Show("Report not applicable for this type of Policy.");
                this.Close();
            }
        }
    }
}
