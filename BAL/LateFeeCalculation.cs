using System;
using System.Collections.Generic;

using System.Text;

using PMF.DAL;
namespace PMF.BAL
{
    public class LateFeeCalculation
    {
    //    public string calc_interest(int Year, int Month, int Day, int mode, double mod_prm, int days_comp)
    //    {
    //        double int_Rate = 0.12;
    //     //   double mod_prm = 3185; //MdPrm.Text
    //        double interest = 0;
    //        double tot_interest = 0;
    //        double tot_amount = 0;
    //     //   int days_comp = 114; // DateDiff("d", SetData.lblDueDate, DateTime.Now);
    //        int mode_days = 0;
    //        int limit_days = 90;
    //        // '********************************************

    //        // cmdLatefee.Enabled = True // this the name of the button
    //        // 'CONVERTING MONTH MODE INTO DAYS ************
    //       // int mode = 0;
    //        if (mode == 3)
    //        {
    //            mode_days = 365 / 4;
    //        }
    //        else if (mode == 6)
    //        {
    //            mode_days = 365 / 2;
    //        }
    //        else
    //        {
    //            mode_days = 365;
    //        }


    //        // 'MAIN LOGIC BEGINS FROM HERE *****************
    //        int status= 20;
    //        if((status==20 || status == 42 || status ==45) && days_comp > 90)
    //        {
    //        do 
    //        {
    //            tot_interest = tot_interest + Math.Pow((mod_prm * (1 + int_Rate)) , (days_comp / 365) - mod_prm);
    //            //due_date = DateAdd("m", Mode.Text, due_date);
    //            DateTime due_date = new DateTime(Year, Month, Day); 
    //            due_date = due_date.AddMonths(mode);
    //             days_comp = Convert.ToInt32(DateTime.Now.Subtract(due_date).TotalDays);
    //            tot_amount = tot_amount + mod_prm;
    //        } 
    //        while (days_comp > limit_days);
            
    //         if( days_comp > 0)
    //         {
    //          tot_amount = tot_amount + mod_prm ;            //'this statement is for the last premiun due
    //         }

    //        }

    //        return tot_interest.ToString();


    //        //TxtLateFee.Text = Format(tot_interest, "#########");
    //        //cmdLatefee.Caption = Format(tot_interest, "#########");
    //        //txtTotPrm.Text = Format(tot_amount + tot_interest, "#########");

    //    }

    }
}
