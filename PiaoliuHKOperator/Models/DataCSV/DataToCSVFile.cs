using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using PiaoliuHKOperator.Models.engine;
using System.Data;
using System.Collections.ObjectModel;
using Windows.Foundation.Collections;

namespace PiaoliuHKOperator.Models.DataCSV
{
    class DataToCSVFile
    {
        private string CSVFileContent { get; set; }
        public string FileName;


        public void setCSVData_List(IList f_List)
        {
            this.CSVFileContent = parseListToData(f_List);
        }

        public async System.Threading.Tasks.Task WriteCSVFileAsync()
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

                await FileIO.WriteBytesAsync(TargetCSVFile, Encoding.UTF8.GetBytes(this.CSVFileContent));
                // 当完成更改时，其他应用程序才可以对该文件进行更改。
                if (await CachedFileManager.CompleteUpdatesAsync(TargetCSVFile) == FileUpdateStatus.Complete)
                {
                    // textBlock.Text = CSVFileName + " 已经保存好了。";
                }
                else
                {
                    // textBlock.Text = CSVFileName + " 保存失败了。";
                }
            }
        }


        private string parseListToData(IList f_List)
        {
            StringBuilder Data_string = new StringBuilder();
            for (int i = 0; i < f_List.Count; i++)
            {
                object Item = f_List[i];
                if (i == 0 && Item != null)
                {
                    foreach (PropertyInfo PropertyInfo_Cell in Item.GetType().GetProperties())
                    {

                        Data_string.Append(PropertyInfo_Cell.Name).Append(Global.CSVCellSeparator);

                    }
                    Data_string.Remove(Data_string.Length - 1, 1).AppendLine();
                }

                foreach (PropertyInfo PropertyInfo_Cell in Item.GetType().GetProperties())
                {
                    Data_string.Append(MakeValueCsvFriendly(PropertyInfo_Cell.GetValue(Item, null))).Append(Global.CSVCellSeparator);
                }

                Data_string.Remove(Data_string.Length - 1, 1).AppendLine();
            }

            return Data_string.ToString();
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
