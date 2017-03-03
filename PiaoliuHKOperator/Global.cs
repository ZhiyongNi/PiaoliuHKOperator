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

        public struct CustomerSelfDefaultAddress_Struct
        {
            public int Tag;
            public string Chinese;
            public string English;
            public string Address;
        };
        public static Dictionary<string, CustomerSelfDefaultAddress_Struct> CustomerSelfDefaultAddress_Dictionary = new Dictionary<string, CustomerSelfDefaultAddress_Struct>() {
            { "CityUniversityofHongKong", new CustomerSelfDefaultAddress_Struct { Tag = 1, Chinese = "香港城市大学", English = "CityUniversityofHongKong", Address = "香港城市大学（香港城市法学图书馆门口）" } },
            { "HongKongBaptistUniversity", new CustomerSelfDefaultAddress_Struct { Tag = 2, Chinese = "香港浸会大学", English = "HongKongBaptistUniversity", Address = "香港浸会大学（九龙塘地铁站A2出口）" } },
            { "ChineseUniversityofHongKong", new CustomerSelfDefaultAddress_Struct { Tag = 3, Chinese = "香港中文大学", English = "ChineseUniversityofHongKong", Address = "香港中文大学（大学地铁站A出口）" } },
            { "EducationUniversityofHongKong", new CustomerSelfDefaultAddress_Struct { Tag = 4, Chinese = "香港教育大学", English = "EducationUniversityofHongKong", Address = "香港教育大学（待填写）" } },
            { "HongKongUniversityofScienceTechnology", new CustomerSelfDefaultAddress_Struct { Tag = 5, Chinese = "香港科技大学", English = "HongKongUniversityofScienceTechnology", Address = "香港科技大学（待填写）" } },
            { "HongKongPolytechnicUniversity", new CustomerSelfDefaultAddress_Struct { Tag = 6, Chinese = "香港理工大学", English = "HongKongPolytechnicUniversity", Address = "香港理工大学（红磡地铁站A1出口）" } },
            { "UniversityofHongKong", new CustomerSelfDefaultAddress_Struct { Tag = 7, Chinese = "香港大学", English = "UniversityofHongKong", Address = "香港大学（新威餐厅）" } },
            { "LingnanUniversity", new CustomerSelfDefaultAddress_Struct { Tag = 8, Chinese = "香港岭南大学", English = "LingnanUniversity", Address = "香港岭南大学（待填写）" } },
            { "MongKok", new CustomerSelfDefaultAddress_Struct { Tag = 9, Chinese = "旺角自提点", English = "MongKok", Address = "旺角自提点（待填写）" } },
            { "KwaiHing", new CustomerSelfDefaultAddress_Struct { Tag = 10, Chinese = "葵兴自提点", English = "KwaiHing", Address = "葵兴自提点（待填写）" } },
            { "ShaTin", new CustomerSelfDefaultAddress_Struct { Tag = 11, Chinese = "沙田自提点", English = "ShaTin", Address = "沙田自提点（待填写）" } },
            { "TaiWai", new CustomerSelfDefaultAddress_Struct { Tag = 12, Chinese = "大围自提点", English = "TaiWai", Address = "大围自提点（待填写）" } },
            { "WanChai", new CustomerSelfDefaultAddress_Struct { Tag = 13, Chinese = "湾仔四合院自提点", English = "WanChai", Address = "湾仔四合院自提点（待填写）" } },
            { "ShiErWei", new CustomerSelfDefaultAddress_Struct { Tag = 14, Chinese = "十二味麻辣自提点", English = "ShiErWei", Address = "十二味麻辣自提点（待填写）" } },
            { "undefined", new CustomerSelfDefaultAddress_Struct { Tag = 99, Chinese = "未定义", English = "undefined", Address = "未定义（待填写）" } } };


        public struct PackageExpressCompany_Struct
        {
            public int Tag;
            public string Chinese;
            public string English;
        };
        public static Dictionary<string, PackageExpressCompany_Struct> PackageExpressCompany_Dictionary = new Dictionary<string, PackageExpressCompany_Struct>() {
            { "ShunfengExpress", new PackageExpressCompany_Struct { Tag = 1, Chinese = "顺丰快递", English = "ShunfengExpress" } },
            { "YuantongExpress", new PackageExpressCompany_Struct { Tag = 2, Chinese = "圆通快递", English = "YuantongExpress" } },
            { "ZhongtongExpress", new PackageExpressCompany_Struct { Tag = 3, Chinese = "中通快递", English = "ZhongtongExpress" } },
            { "YundaExpress", new PackageExpressCompany_Struct { Tag = 4, Chinese = "韵达快递", English = "YundaExpress" } },
            { "ShentongExpress", new PackageExpressCompany_Struct { Tag = 5, Chinese = "申通快递", English = "ShentongExpress" } },
            { "EMSExpress", new PackageExpressCompany_Struct { Tag = 6, Chinese = "EMS快递", English = "EMSExpress" } },
            { "HuitongExpress", new PackageExpressCompany_Struct { Tag = 7, Chinese = "汇通快递", English = "HuitongExpress" } },
            { "TiantianExpress", new PackageExpressCompany_Struct { Tag = 8, Chinese = "天天快递", English = "TiantianExpress" } },
            { "YousuExpress", new PackageExpressCompany_Struct { Tag = 9, Chinese = "优速快递", English = "YousuExpress" } },
            { "BestExpress", new PackageExpressCompany_Struct { Tag = 10, Chinese = "百世汇通", English = "BestExpress" } },
            { "GuotongExpress", new PackageExpressCompany_Struct { Tag = 11, Chinese = "国通快递", English = "GuotongExpress" } },
            { "LongbangExpress", new PackageExpressCompany_Struct { Tag = 12, Chinese = "龙邦快递", English = "LongbangExpress" } },
            { "SuerExpress", new PackageExpressCompany_Struct { Tag = 13, Chinese = "速尔快递", English = "SuerExpress" } },
            { "HuiqiangExpress", new PackageExpressCompany_Struct { Tag = 14, Chinese = "汇强快递", English = "HuiqiangExpress" } },
            { "ZJSExpress", new PackageExpressCompany_Struct { Tag = 15, Chinese = "宅急送快递", English = "ZJSExpress" } },
            { "QuanfengExpress", new PackageExpressCompany_Struct { Tag = 16, Chinese = "全峰快递", English = "QuanfengExpress" } },
            { "RufengdaExpress", new PackageExpressCompany_Struct { Tag = 17, Chinese = "如风达", English = "RufengdaExpress" } },
            { "SJFDExpress", new PackageExpressCompany_Struct { Tag = 18, Chinese = "顺捷丰达", English = "SJFDExpress" } },
            { "FastExpress", new PackageExpressCompany_Struct { Tag = 19, Chinese = "快捷快递", English = "FastExpress" } },

            { "JingdongExpress", new PackageExpressCompany_Struct { Tag = 51, Chinese = "京东快递", English = "JingdongExpress" } },
            { "SuningExpress", new PackageExpressCompany_Struct { Tag = 52, Chinese = "苏宁快递", English = "SuningExpress" } },
            { "DangdangExpress", new PackageExpressCompany_Struct { Tag = 53, Chinese = "当当官方快递", English = "DangdangExpress" } },
            { "AmazonExpress", new PackageExpressCompany_Struct { Tag = 54, Chinese = "亚马逊官方快递", English = "AmazonExpress" } },
            { "YHDExpress", new PackageExpressCompany_Struct { Tag = 55, Chinese = "一号店快递", English = "YHDExpress" } },

            { "Unknown", new PackageExpressCompany_Struct { Tag = 99, Chinese = "未知", English = "Unknown" } }
        };
    }
}
