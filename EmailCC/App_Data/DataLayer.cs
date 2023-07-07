using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
namespace EmailCC
{
    public class DataLayer
    {
        public DataSet RetrieveDataset(string spName)
        {
            DataSet _ds;
            string strCon = ConfigurationSettings.AppSettings["transactiondbLF"];
            _ds = SqlHelper.ExecuteDataset(strCon, CommandType.StoredProcedure, spName);
            return _ds;
        }
        public int Insertrecord(string spName, SqlParameter[] sqlParam)
        {
            string cnStr = ConfigurationSettings.AppSettings["transactiondbLF"];
            int result;
            result = SqlHelper.ExecuteNonQuery(cnStr, CommandType.StoredProcedure, spName, sqlParam);
            return result;
        }
    }
}