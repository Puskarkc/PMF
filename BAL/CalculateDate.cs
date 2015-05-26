using System;
using System.Collections.Generic;

using System.Text;


namespace PMF.BAL
{
    public class CalculateDate
    {
        string dateNew;
        public string calcDate(int Day, int Month, int Year, int mode)
        {

            int addedMonth = Month + mode;
            int newMonth;
            int newYear;
            if (addedMonth > 12)
            {
                newYear = 2000+Year + 1;

                newMonth = addedMonth - 12;
            }
            else
            {
                newMonth = addedMonth;
                newYear = 2000 +Year;
            }

            dateNew = Day + "/" + newMonth + "/" + newYear; //dd mm yy


            return dateNew;
        }

        public double DateDifference(int Day, int Month, int Year)
        {
            double noOfDaysEllapsed = 0;
            DateTime dueDate = new DateTime(Year, Month, Day);
            noOfDaysEllapsed = DateTime.Today.Subtract(dueDate).TotalDays;

            return noOfDaysEllapsed;
        }
    }
}
