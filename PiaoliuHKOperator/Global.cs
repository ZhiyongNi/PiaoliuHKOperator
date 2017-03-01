using PiaoliuHKOperator.Models.core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator
{
    class Global
    {
        public static TcpClient OperatorClientSocket;
        public static String OperatorServer_Host = "127.0.0.1";
        //public static String OperatorServer_Host = "120.77.253.194";
        public static Int16 OperatorServer_Port = 20000;
        public static char SocketDelimiter = '\n';
        public static char SyncDelimiter = '|';

        public static Admin myAdmin;

        public struct TransitBillStatus_Struct
        {
            public int Tag;
            public string Chinese;
            public string English;
        };
        public static Dictionary<string, TransitBillStatus_Struct> TransitBillStatus_Dictionary = new Dictionary<string, TransitBillStatus_Struct>() {
           { "Signed", new TransitBillStatus_Struct { Tag = 1, Chinese = "已签收", English = "Signed" } },
           { "Pickingup", new TransitBillStatus_Struct { Tag = 2, Chinese = "派件中", English = "Pickingup" } },
           { "Loading", new TransitBillStatus_Struct { Tag = 3, Chinese = "已装车", English = "Loading" } },
           { "Scheduling", new TransitBillStatus_Struct { Tag = 4, Chinese = "正安排出库", English = "Scheduling" } },
           { "Checkin", new TransitBillStatus_Struct { Tag = 5, Chinese = "待香港收包", English = "Checkin" } },
           { "inCustoms", new TransitBillStatus_Struct { Tag = 6, Chinese = "海关清关中", English = "inCustoms" } },
           { "Checkout", new TransitBillStatus_Struct { Tag = 7, Chinese = "待深圳库出包", English = "Checkout" } },
           { "Pending", new TransitBillStatus_Struct { Tag = 8, Chinese = "待配齐", English = "Pending" } }
        };

        public struct PackageStatus_Struct
        {
            public int Tag;
            public string Chinese;
            public string English;
        };
        public static Dictionary<string, PackageStatus_Struct> PackageStatus_Dictionary = new Dictionary<string, PackageStatus_Struct>() {
            { "Signed", new PackageStatus_Struct { Tag = 1, Chinese = "已签收", English = "Signed" } },
            { "Pickingup", new PackageStatus_Struct { Tag = 2, Chinese = "派件中", English = "Pickingup" } },
            { "Loading", new PackageStatus_Struct { Tag = 3, Chinese = "已装车", English = "Loading" } },
            { "Scheduling", new PackageStatus_Struct { Tag = 4, Chinese = "正安排出库", English = "Scheduling" } },
            { "Checkin", new PackageStatus_Struct { Tag = 5, Chinese = "待香港收包", English = "Checkin" } },
            { "inCustoms", new PackageStatus_Struct { Tag = 6, Chinese = "海关清关中", English = "inCustoms" } },
            { "Checkout", new PackageStatus_Struct { Tag = 7, Chinese = "待深圳库出包", English = "Checkout" } },
            { "Pending", new PackageStatus_Struct { Tag = 8, Chinese = "待配齐", English = "Pending" } },
            { "unMatched", new PackageStatus_Struct { Tag = 9, Chinese = "未查询匹配", English = "unMatched" } }
        };
        public static class PiaoliuHK_Configs_GlobalConstant_StationAddress
        {
            static String Country = "中国";
            static String Province = "广东";
            static String City = "深圳市";
            static String District = "龙岗区";
            static String Streets = "横岗街道";
            static String Apartment = "振业城综合大楼176号商铺漂流瓶";
            static String ZipCode = "518173";
            static String Mobile = "15818786460";
            static String Tele = "12345678";
        }
        public static class PiaoliuHK_Configs_GlobalConstant_TransitBillMethod
        {
            static int ExpressPick = 0;
            static String ExpressChinese = "A.学校及居住区定点派送 ";
            static String ExpressShortChinese = "送货上门";
            static int HousePick = 1;
            static String HousePickChinese = "B.香港仓库自行取货";
            static String HousePickShortChinese = "仓库自取";
            static int SelfPick = 2;
            static String SelfPickChinese = "C.送往指定地点门 ";
            static String SelfPickShortChinese = "服务点待提";
        }


        public struct CustomerSelfDefaultAddress_Struct
        {
            public int Tag;
            public string ChineseName;
            public string EnglishName;
            public string Address;
        };
        public static List<CustomerSelfDefaultAddress_Struct> CustomerSelfDefaultAddress_List = new List<CustomerSelfDefaultAddress_Struct>() {
            new CustomerSelfDefaultAddress_Struct { Tag = 1, ChineseName = "香港城市大学", EnglishName = "CityUniversityofHongKong", Address = "香港城市大学（香港城市法学图书馆门口）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 2, ChineseName = "香港浸会大学", EnglishName = "HongKongBaptistUniversity",Address = "香港浸会大学（九龙塘地铁站A2出口）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 3, ChineseName = "香港中文大学", EnglishName = "ChineseUniversityofHongKong",Address = "香港中文大学（大学地铁站A出口）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 4, ChineseName = "香港教育大学", EnglishName = "EducationUniversityofHongKong",Address = "香港教育大学（待填写）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 5, ChineseName = "香港科技大学", EnglishName = "HongKongUniversityofScienceTechnology",Address = "香港科技大学（待填写）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 6, ChineseName = "香港理工大学", EnglishName = "HongKongPolytechnicUniversity",Address = "香港理工大学（红磡地铁站A1出口）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 7, ChineseName = "香港大学", EnglishName = "UniversityofHongKong",Address = "香港大学（新威餐厅）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 8, ChineseName = "香港岭南大学", EnglishName = "LingnanUniversity",Address = "香港岭南大学（待填写）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 9, ChineseName = "旺角自提点", EnglishName = "MongKok",Address = "旺角自提点（待填写）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 10, ChineseName = "葵兴自提点", EnglishName = "KwaiHing",Address = "葵兴自提点（待填写）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 11, ChineseName = "沙田自提点", EnglishName = "ShaTin",Address = "沙田自提点（待填写）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 12, ChineseName = "大围自提点", EnglishName = "TaiWai",Address = "大围自提点（待填写）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 13, ChineseName = "湾仔四合院自提点", EnglishName = "WanChai",Address = "湾仔四合院自提点（待填写）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 14, ChineseName = "十二味麻辣自提点", EnglishName = "ShiErWei",Address = "十二味麻辣自提点（待填写）" },
            new CustomerSelfDefaultAddress_Struct { Tag = 99, ChineseName = "未定义", EnglishName = "undefined",Address = "未定义（待填写）" }
        };
    }
}
