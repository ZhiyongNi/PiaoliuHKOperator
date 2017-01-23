using PiaoliuHKOperator.Models.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaoliuHKOperator.Models.engine
{
    class PackageList
    {
        public String ExcuteCommand;
        public List<Package> PackageItemList = new List<Package>();
        public void findAllPackagebyFilter(string FilterString)
        { }
    }
}
