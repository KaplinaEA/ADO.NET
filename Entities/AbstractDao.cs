using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    abstract public class AbstractDao
    {
        protected string _connectionString = ConfigurationManager.ConnectionStrings["JournalDB"].ConnectionString;

        public void AddSqlParameters(SqlCommand command, SqlParameter[] parameters)
        {
            foreach(var item in parameters)
                command.Parameters.Add(item);
            
        }
    }
}
