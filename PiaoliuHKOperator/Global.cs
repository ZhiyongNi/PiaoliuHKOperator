using PiaoliuHKOperator.Models.core;
using System;
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
        //public static String OperatorServer_Host = "192.168.31.142";
        public static Int16 OperatorServer_Port = 20000;
        public static char SocketDelimiter = '\n';
        public static char SyncDelimiter = '|';

        public static Admin myAdmin;

        public static class TransitBillStatus
        {
            static int Signed = 1;
            static String SignedChinese = "已签收";
            static int Pickingup = 2;
            static String PickingupChinese = "派件中";
            static int Loading = 3;
            static String LoadingChinese = "已装车";
            static int Scheduling = 4;
            static String SchedulingChinese = "正安排出库";
            static int Checkin = 5;
            static String CheckinChinese = "待香港收包";
            static int inCustoms = 6;
            static String inCustomsChinese = "海关清关中";
            static int Checkout = 7;
            static String CheckoutChinese = "待深圳库出包";
            static int Pending = 8;
            static String PendingChinese = "待配齐";
        }
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


        public struct SelfPickupAddress_Struct
        {
            public int ID;
            public string ChineseName;
            public string EnglishName;
            public string Address;
        };
        public static List<SelfPickupAddress_Struct> SelfPickupAddress_List = new List<SelfPickupAddress_Struct> {
            new SelfPickupAddress_Struct { ID = 1, ChineseName = "香港城市大学", EnglishName = "CityUniversityofHongKong", Address = "香港城市大学（香港城市法学图书馆门口）" },
            new SelfPickupAddress_Struct { ID = 2, ChineseName = "香港浸会大学", EnglishName = "HongKongBaptistUniversity",Address = "香港浸会大学（九龙塘地铁站A2出口）" },
            new SelfPickupAddress_Struct { ID = 3, ChineseName = "香港中文大学", EnglishName = "ChineseUniversityofHongKong",Address = "香港中文大学（大学地铁站A出口）" },
            new SelfPickupAddress_Struct { ID = 4, ChineseName = "香港教育大学", EnglishName = "EducationUniversityofHongKong",Address = "香港教育大学（待填写）" },
            new SelfPickupAddress_Struct { ID = 5, ChineseName = "香港科技大学", EnglishName = "HongKongUniversityofScienceTechnology",Address = "香港科技大学（待填写）" },
            new SelfPickupAddress_Struct { ID = 6, ChineseName = "香港理工大学", EnglishName = "HongKongPolytechnicUniversity",Address = "香港理工大学（红磡地铁站A1出口）" },
            new SelfPickupAddress_Struct { ID = 7, ChineseName = "香港大学", EnglishName = "UniversityofHongKong",Address = "香港大学（新威餐厅）" },
            new SelfPickupAddress_Struct { ID = 8, ChineseName = "香港岭南大学", EnglishName = "LingnanUniversity",Address = "香港岭南大学（待填写）" },
            new SelfPickupAddress_Struct { ID = 9, ChineseName = "旺角自提点", EnglishName = "MongKok",Address = "旺角自提点（待填写）" },
            new SelfPickupAddress_Struct { ID = 10, ChineseName = "葵兴自提点", EnglishName = "KwaiHing",Address = "葵兴自提点（待填写）" },
            new SelfPickupAddress_Struct { ID = 11, ChineseName = "沙田自提点", EnglishName = "ShaTin",Address = "沙田自提点（待填写）" },
            new SelfPickupAddress_Struct { ID = 12, ChineseName = "大围自提点", EnglishName = "TaiWai",Address = "大围自提点（待填写）" },
            new SelfPickupAddress_Struct { ID = 13, ChineseName = "湾仔四合院自提点", EnglishName = "WanChai",Address = "湾仔四合院自提点（待填写）" },
            new SelfPickupAddress_Struct { ID = 14, ChineseName = "十二味麻辣自提点", EnglishName = "ShiErWei",Address = "十二味麻辣自提点（待填写）" },
            new SelfPickupAddress_Struct { ID = 99, ChineseName = "未定义", EnglishName = "undefined",Address = "未定义（待填写）" }
        };
    }
}
