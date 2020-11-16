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
    public class PlaneDataProvider
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["AirlineConnectionString"].ConnectionString;
        
        public List<PlaneDetailDao> GetPlaneDetails()
        {
            var queryString = @"SELECT Id, Type, NoRow_FirstClass, NoCol_FirstClass, NoRow_EcoClass, NoCol_EcoClass FROM PlaneDetails";
            var ds = new DataSet();

            using (var connection = new SqlConnection(connectionString))
            {
                try { 
                    var command = new SqlCommand(queryString, connection);
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                    catch (SqlException sqlError)
                {
                }
            }

            var planeDetails = ds.Tables.Count != 0 ? ds.Tables[0].AsEnumerable()
                .Select(dataRow => new PlaneDetailDao
                {
                    PlaneId = dataRow.Field<Guid>("Id"),
                    PlaneType = dataRow.Field<string>("Type"),
                    NoRow_FirstClass = dataRow.Field<short>("NoRow_FirstClass"),
                    NoCol_FirstClass = dataRow.Field<short>("NoCol_FirstClass"),
                    NoRow_EcoClass = dataRow.Field<short>("NoRow_EcoClass"),
                    NoCol_EcoClass = dataRow.Field<short>("NoCol_EcoClass")
                }).ToList() : null;

            return planeDetails;
        }
    }
}
