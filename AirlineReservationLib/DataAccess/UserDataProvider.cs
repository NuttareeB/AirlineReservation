using Enum;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDataProvider
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["AirlineConnectionString"].ConnectionString;

        private int ToIntOrDefault(string s)
        {
            int result;
            return int.TryParse(s, out result) ? result : 0;
        }

        public UserDao GetUserByUsername(string username)
        {
            var queryString = @"SELECT Id, Username, FirstName, LastName, Age, Role, DateCreated, DateModified, Password
                                FROM Users WHERE Username = @Username";

            var ds = new DataSet();

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    var command = new SqlCommand(queryString, connection);
                    var da = new SqlDataAdapter(command);
                    command.Parameters.AddWithValue("@Username", username);
                    da.Fill(ds);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException sqlError)
                {
                }
            }

            var userDetails = ds.Tables.Count != 0 ? ds.Tables[0].AsEnumerable()
                .Select(dataRow => new UserDao(
                    dataRow.Field<Guid>("Id"),
                    dataRow.Field<string>("Username"),
                    dataRow.Field<string>("FirstName"), 
                    dataRow.Field<string>("LastName"), 
                    dataRow.Field<short>("Age"), 
                    dataRow.Field<string>("Role").Split(',').Select(r => (Role)ToIntOrDefault(r)).ToList(), 
                    dataRow.Field<string>("Password"))
                ).ToList() : null;

            return (userDetails != null && userDetails.Count > 0) ? userDetails[0] : null;
        }
    }
}
