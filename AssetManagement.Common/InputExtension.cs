using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetManagement.Common
{
    public static class InputExtension
    {
        public static bool ComboboxControl(this ComboBox cmb)
        {
            if (cmb.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDateRange(this DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                return false;
            }
            return true;
        }


        public static bool IsValidEmptyNumeric(this string numeric)
        {
            if (string.IsNullOrWhiteSpace(numeric))
                return false;

            return true;
        }



    }
}
