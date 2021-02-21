using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.XML
{
    public class XMLTEST
    {
        public string ser()
        {



            SAS_STOCK_BSC sas_stock_bsc = new SAS_STOCK_BSC
            {
                CORP_INNER_NO = "111",
                DCL_TYPECD = "222"
            };

            SAS_STOCK_DT sas_stock_dt = new SAS_STOCK_DT
            {
                SAS_DCL_SEQNO = "333",
                SAS_STOCK_SEQNO = "444"
            };

            List<SAS_STOCK_DT> list = new List<SAS_STOCK_DT>();
            list.Add(sas_stock_dt);
            list.Add(sas_stock_dt);

            var arr = new SAS_STOCK_DT[]
            {
                sas_stock_dt,
                sas_stock_dt
            };

            MESSAGE<MESSAGE_BODY_SAS_STOCK>  message = new MESSAGE<MESSAGE_BODY_SAS_STOCK> 
            {
                MESSAGE_HEAD = new MESSAGE_HEAD
                {
                    HASH_SIGN = "",
                    MESSAGE_ID = "55",
                    MESSAGE_TYPE = "5",
                    RECEIVE_ID = "11",
                    SENDER_ID = "33",
                    SEND_TIME = "7"
                },
                MESSAGE_BODY = new MESSAGE_BODY_SAS_STOCK { SAS_STOCK_BSC = sas_stock_bsc, SAS_STOCK_DT = list.ToArray() }

            };

            //string xml = message.ToXml("MESSAGE").ToString();

            //return xml;

            //string xml = "";
            //var res = ObjectToXML.Deserialize(typeof(MESSAGE), xml);


            var result = ObjectToXML.Serializer(typeof(MESSAGE<MESSAGE_BODY_SAS_STOCK>), message);
            Console.WriteLine(result);
            return result;
        }


       
        
    }
}
