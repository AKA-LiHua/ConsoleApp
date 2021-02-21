using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.XML
{
    public class SAS_STOCK_BSC
    {
        /// <summary>
        /// 企业内部编码
        /// 同一家企业同一个报文类型必须 唯一
        /// </summary>
        public string CORP_INNER_NO { get; set; }

        /// <summary>
        /// 申报类型代码
        /// 1-备案、3-作废
        /// </summary>
        public string DCL_TYPECD { get; set; }
    }
}
