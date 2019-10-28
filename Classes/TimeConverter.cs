using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter<string>
    {
        public string convertTime(Time aTime)
        {
            var result = new StringBuilder();
            ForHours(aTime.Hours, result);
            ForMinutes(aTime.Minutes, result);
            ForSeconds(aTime.Seconds, result);
            return result.ToString().TrimEnd();
        }

        private static readonly Dictionary<int, string> LampOnByRow = new Dictionary<int, string>
        {
            { 0, "Y" },
            { 1, "RRRR" },
            { 2, "RRRR" },
            { 3, "YYRYYRYYRYY" },
            { 4, "YYYY" }
        };

        //Method to get hours in 1st,2nd rows
        private void ForHours(int hrs, StringBuilder result)
        {
            var firstRowOnCount = hrs / 5;
            var secondRowOnCount = hrs % 5;
            TimeByRow(1, firstRowOnCount, result);
            TimeByRow(2, secondRowOnCount, result);
        }

        //Method to get minutes in 3,4th row
        private void ForMinutes(int min, StringBuilder result)
        {
            var thirdRowCount = min / 5;
            var forthRowCount = min % 5;
            TimeByRow(3, thirdRowCount, result);
            TimeByRow(4, forthRowCount, result);
        }

        //Method to get seconds
        private void ForSeconds(int sec, StringBuilder result)
        {
            var onCount = ((sec % 2) == 0) ? 1 : 0;
            TimeByRow(0, onCount, result);
        }

        //Method to get the status of the Lamp: On or Off
        private string GetLampOutput(int row, int column, bool status)
        {
            if(!status) 
                return "O";
            else
               return LampOnByRow[row][column].ToString();
        }


        private void TimeByRow(int lampsOnCount, int rowNum, StringBuilder result)
        {
            bool on;
            var rowLength = LampOnByRow[rowNum].Length;
            for (int lamp = 0; lamp < rowLength; lamp++)
            {
                on = lampsOnCount > lamp;
                result.Append(GetLampOutput(rowNum, lamp, on));
            }
            result.AppendLine();
        }
    }
}
