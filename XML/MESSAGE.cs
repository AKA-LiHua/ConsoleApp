using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1.XML
{

    [XmlRoot("MESSAGE")]
    public class MESSAGE<T> where T : class
    {
        public MESSAGE_HEAD MESSAGE_HEAD { get; set; }

        public T MESSAGE_BODY { get; set; }
    }

    public class MESSAGE_HEAD
    {
        /// <summary>
        /// 报文唯一编号
        /// 保证唯一性，SENDER_ID（8 位）+ RECEIVE_ID （8 位）+ 时间 yyyyMMdd（8 位）+（9 位） 序列号（各自保证唯一）
        /// </summary>
        public string MESSAGE_ID { get; set; }

        /// <summary>
        /// 报文类型
        /// SAS001 物流账册
        /// SAS002 加工贸易账册
        /// SAS003 核注清单
        /// SAS004 核放单
        /// SAS005 申报表
        /// SAS006 出入库单
        /// SAS007 过卡凭单
        /// </summary>
        public string MESSAGE_TYPE { get; set; }

        /// <summary>
        /// 发送方唯一编号
        /// </summary>
        public string SENDER_ID { get; set; }

        /// <summary>
        /// 接收方编号
        /// </summary>
        public string RECEIVE_ID { get; set; }

        /// <summary>
        /// 发送时间 
        /// 格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string SEND_TIME { get; set; }

        /// <summary>
        /// 签名信息
        /// </summary>
        public string HASH_SIGN { get; set; }
    }


    [XmlRoot("MESSAGE_BODY")]
    public class MESSAGE_BODY_SAS_STOCK
    {
        public SAS_STOCK_BSC SAS_STOCK_BSC { get; set; }
        [XmlElement]
        public SAS_STOCK_DT[] SAS_STOCK_DT { get; set; }
    }
}
