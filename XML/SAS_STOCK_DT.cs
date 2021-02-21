using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1.XML
{
    [XmlRoot("SAS_STOCK_DT")]
    public class SAS_STOCK_DT
    {
        /// <summary>
        /// 商品序号
        /// </summary>
        public string SAS_STOCK_SEQNO { get; set; }

        /// <summary>
        /// 申报表序号
        /// </summary>
        public string SAS_DCL_SEQNO { get; set; }
    }
}
