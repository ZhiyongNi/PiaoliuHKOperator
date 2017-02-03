using PiaoliuHKOperator.Models.core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Reflection;

namespace PiaoliuHKOperator.Models.engine.DataCSV
{
    class DataToCSV
    {
        private static string ListSeparator = ",";

        public static string parseListToCSV(IList f_DataList)
        {
            IList DataList = f_DataList;
            StringBuilder CSVString = new StringBuilder();
            TypeInfo propertyInfos = typeof(TransitBillCheckoutCSVItem).GetTypeInfo();

            if (true)//includeHeaderLine
            {
                //add header line.
                foreach (var propertyInfo in propertyInfos.DeclaredProperties)
                {
                    CSVString.Append(propertyInfo.Name).Append(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }
                CSVString.Remove(CSVString.Length - 1, 1).AppendLine();
            }

            //add value for each property.
            foreach (object obj in DataList)
            {
                foreach (var propertyInfo in propertyInfos.DeclaredProperties)
                {
                    CSVString.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }

                CSVString.Remove(CSVString.Length - 1, 1).AppendLine();
            }

            return CSVString.ToString();
        }

        //get the csv value for field.
        private static string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";

            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                    return ((DateTime)value).ToString("yyyy-MM-dd");
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            string output = value.ToString();

            if (output.Contains(",") || output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';

            return output;

        }
    }
}
