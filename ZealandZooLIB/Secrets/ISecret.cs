using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandZooLIB.Secrets
{
    internal interface ISecret
    {
        // Hostname   : mssql5.unoeuro.com
        // Brugernavn : bullerbob_dk
        // kode       : 49xceBEtdHA36mnDwhpF
        String GetSecret();

    }
}
