using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;

namespace PiaoliuHKOperator.Models.engine.DataCSV
{
    class DataToCSV
    {
        private static string ListSeparator = ",";
        public List<object> CSVItem_List = new List<object>();
        public string FileName;


        public void setCSVItem_List(object f)
        {
            //string CSVContent = DataToCSV.parseListToCSV(（List）f);
        }
        public async System.Threading.Tasks.Task<FileUpdateStatus> WriteCSVFileAsync()
        {
            FileSavePicker FileSavePicker_Instance = new FileSavePicker();
            FileSavePicker_Instance.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;

            FileSavePicker_Instance.FileTypeChoices.Add("CSV（逗号分隔）", new List<string>() { ".csv" });
            FileSavePicker_Instance.SuggestedFileName = FileName;


            StorageFile TargetCSVFile = await FileSavePicker_Instance.PickSaveFileAsync();
            if (TargetCSVFile != null)
            {
                // 在用户完成更改并调用CompleteUpdatesAsync之前，阻止对文件的更新
                CachedFileManager.DeferUpdates(TargetCSVFile);

                await FileIO.WriteBytesAsync(TargetCSVFile, Encoding.UTF8.GetBytes(CSVContent));
                // 当完成更改时，其他应用程序才可以对该文件进行更改。
                FileUpdateStatus updateStatus = await CachedFileManager.CompleteUpdatesAsync(TargetCSVFile);

                if (updateStatus == FileUpdateStatus.Complete)
                {
                   // textBlock.Text = CSVFileName + " 已经保存好了。";
                }
                else
                {
                   // textBlock.Text = CSVFileName + " 保存失败了。";
                }

                return updateStatus;
        }


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
