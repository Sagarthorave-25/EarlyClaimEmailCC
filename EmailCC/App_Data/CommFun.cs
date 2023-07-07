using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmailCC
{
    public class CommFun
    {
        DataLayer objsql = new DataLayer();
        public DataSet Get_All_EMAILDATA()
        {
            DataSet ds=new DataSet();
            try
            {
                ds = objsql.RetrieveDataset("Sp_FeatchT_CLAIMS_relatedyourtaskname");
            }
            catch (Exception Error)
            {
            }
            return ds;
        }
        public void UpdateStatusInactive(int id)
        {
            try
            {
                SqlParameter[] _sqlparam = new SqlParameter[1];
                _sqlparam[0] = new SqlParameter("@Id", id);
                objsql.Insertrecord("Sp_UpdateStatus_T_CLAIMS_relatedyourtaskname", _sqlparam);
            }
            catch (Exception Error)
            {
                string msg = Error.Message;
            }
        }
        public void InsertDataEmailCC(string email, string status,string user)
        {
            try
            {
                SqlParameter[] _sqlparam = new SqlParameter[3];
                _sqlparam[0] = new SqlParameter("@Email", email);
                _sqlparam[1] = new SqlParameter("@Status", status);
                _sqlparam[2] = new SqlParameter("@CreatedBy", user);

                objsql.Insertrecord("Sp_Insert_T_CLAIMS_relatedyourtaskname", _sqlparam);
            }
            catch (Exception Error)
            {
                string msg = Error.Message;
            }
        }

        public void UpdateEmail(int id, string email, string status, string user )
        {
            try
            {
                SqlParameter[] _sqlparam = new SqlParameter[4];
                _sqlparam[0] = new SqlParameter("@Email", email);
                _sqlparam[1] = new SqlParameter("@Status", status);
                _sqlparam[2] = new SqlParameter("@UserId", user);
                _sqlparam[3] = new SqlParameter("@Id", id);
                objsql.Insertrecord("Sp_Update_T_CLAIMS_relatedyourtaskname", _sqlparam);
            }
            catch (Exception Error)
            {
                string msg = Error.Message;
            }
        }
    }
}