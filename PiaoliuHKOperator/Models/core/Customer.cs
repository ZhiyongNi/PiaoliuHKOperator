using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.core
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerRealName { get; set; }
        public int CustomerGender { get; set; }
        public string CustomerSelfMobile { get; set; }
        public string CustomerSelfDefaultAddress { get; set; }
        public string CustomerSelfDirectAddress { get; set; }
        public string CustomerSelfOtherAddress { get; set; }
        public string CustomerCollage { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerQQ { get; set; }
        public string CustomerWeixin { get; set; }
        public string CustomerAlipay { get; set; }
        public string CustomerAvatarMobile { get; set; }
        public string CustomerAvatarAddress { get; set; }
        public int CustomerAccountStatus { get; set; }
    }
}
