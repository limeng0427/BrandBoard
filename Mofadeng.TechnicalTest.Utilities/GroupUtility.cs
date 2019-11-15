using System;
using System.Collections.Generic;
using System.Text;

namespace Mofadeng.TechnicalTest.Utilities
{
    public static class GroupUtility
    {
        /// <summary>
        /// Get Group Name By [ItemName] and optional [GroupInitialTypeNumbers], e.g. A, A-B, A-C, A-D
        /// </summary>
        /// <param name="name"></param>
        /// <param name="groupItemNumber"></param>
        /// <returns></returns>
        public static string GetGroupName(string name, int groupItemNumber = 2)
        {
            char initial = name.ToUpper()[0];
            int initialAscCode = (int)initial;

            if (initialAscCode < 65 || initialAscCode > 90)
                return "Others";
            if (groupItemNumber < 2)
                return initial.ToString();

            int quotient = (initialAscCode - 65) / groupItemNumber;
            int remainder = (initialAscCode - 65) % groupItemNumber;
            string result = string.Empty;
            for (int i = 0; i < groupItemNumber; i++)
            {
                if (i == 0)
                    result += (char)(65 + quotient * groupItemNumber);
                else if (i == 90 || i == groupItemNumber - 1)
                    result += "-" + (char)(65 + quotient * groupItemNumber + i);
            }
            return result;
        }
    }
}
