using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.data
{
    class BeastManager
    {
        private String con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();


        using (SqlConnection myConnection = new SqlConnectionStringBuilder(con)){

    }
}
