using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiaoliuHKOperator.Models.engine;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using PiaoliuHKOperator.Models.network;

namespace PiaoliuHKOperator.Models.core
{
    class Admin
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public int AdminType { get; set; }
        public string AdminMobile { get; set; }
        public string AdminRealName { get; set; }
        public string AdminEmail { get; set; }
        public int AdminAccountStatus { get; set; }
        public Boolean isAuthorized { get; set; }

        public void AuthAdminbyNameandPassword(string f_UserName, string f_Password)
        {
            this.AdminName = f_UserName;
            this.AdminPassword = f_Password;

            SyncThisbyMethod("AuthAdminbyNameandPassword");

        }
        public void addAdminNewRecoder() { }

        private void setAdminID() { }
        private void SyncThisbyMethod(string f_TargetMethod)
        {
            SyncClass SyncClass_Instance = new SyncClass(this.GetType().FullName, f_TargetMethod, JsonConvert.SerializeObject(this));
            SyncClass_Instance.SyncbySocket();

            if (SyncClass_Instance.SyncSucceed)
            {
                CloneThis(JsonConvert.DeserializeObject<Admin>(SyncClass_Instance.SyncJsonString));
            }
        }
        private void CloneThis(Admin f_Admin)
        {
            this.AdminID = f_Admin.AdminID;
            this.AdminName = f_Admin.AdminName;
            this.AdminPassword = f_Admin.AdminPassword;
            this.AdminType = f_Admin.AdminType;
            this.AdminMobile = f_Admin.AdminMobile;
            this.AdminRealName = f_Admin.AdminRealName;
            this.AdminEmail = f_Admin.AdminEmail;
            this.AdminAccountStatus = f_Admin.AdminAccountStatus;
            this.isAuthorized = f_Admin.isAuthorized;
        }
    }
}
