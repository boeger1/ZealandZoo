using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandZooLIB.Secrets
{
        public static class Secret
        {
        
        public static string GetSecret()
            {
                return "Data Source=mssql5.unoeuro.com;User ID=bullerbob_dk;Password=49xceBEtdHA36mnDwhpF;Initial Catalog=bullerbob_dk_db_zealandzoo;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            }
        }
    
}
