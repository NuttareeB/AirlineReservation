using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    class FlightDataProvider
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["AirlineConnectionString"].ConnectionString;

        public FlightAndPlaneDetailDao GetFlightAndPlaneDetailsByFlightId(Guid flightId)
        {
            var queryString = @"SELECT fd.Id AS FlightId ,FlightNo ,PlaneId ,DepartureAirport ,ArrivalAirport ,DepartureTime ,ArrivalTime
                                , FirstClassPrice, EconomyClassPrice, IsAvailable, Type as PlaneType, NoRow_FirstClass, NoCol_FirstClass
                                , NoRow_EcoClass, NoCol_EcoClass, FirstClassCapacity, EcoClassCapacity  FROM FlightDetails fd, PlaneDetails pd
                                 WHERE fd.PlaneId = pd.Id AND fd.Id = @FlightId";
            var flightDetails = GetFlightAndPlaneDetailsFromDB(queryString, flightId);
            return flightDetails?.Count > 0 ? flightDetails[0] : null;
        }

        public List<FlightAndPlaneDetailDao> GetAllFlightAndPlaneDetails()
        {
            var queryString = @"SELECT fd.Id AS FlightId ,FlightNo ,PlaneId ,DepartureAirport ,ArrivalAirport ,DepartureTime ,ArrivalTime
                                , FirstClassPrice, EconomyClassPrice, IsAvailable, Type as PlaneType, NoRow_FirstClass, NoCol_FirstClass
                                , NoRow_EcoClass, NoCol_EcoClass, FirstClassCapacity, EcoClassCapacity  FROM FlightDetails fd, PlaneDetails pd WHERE fd.PlaneId = pd.Id";
            return GetFlightAndPlaneDetailsFromDB(queryString);
        }

        private List<FlightAndPlaneDetailDao> GetFlightAndPlaneDetailsFromDB(string queryString, Guid flightId = default(Guid))
        {
            var ds = new DataSet();

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    var command = new SqlCommand(queryString, connection);
                    var da = new SqlDataAdapter(command);
                    if (flightId != Guid.Empty)
                    {
                        command.Parameters.AddWithValue("@FlightId", flightId);
                    }
                    da.Fill(ds);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException sqlError)
                {
                }
            }

            var flightAndPlaneDetails = ds.Tables.Count != 0 ? ds.Tables[0].AsEnumerable()
                .Select(dataRow => new FlightAndPlaneDetailDao
                {
                    FlightId = dataRow.Field<Guid>("FlightId"),
                    FlightNo = dataRow.Field<string>("FlightNo"),
                    PlaneId = dataRow.Field<Guid>("PlaneId"),
                    DepartureAirport = dataRow.Field<string>("DepartureAirport"),
                    ArrivalAirport = dataRow.Field<string>("ArrivalAirport"),
                    DepartureTime = dataRow.Field<DateTime>("DepartureTime"),
                    ArrivalTime = dataRow.Field<DateTime>("ArrivalTime"),
                    FirstClassPrice = dataRow.Field<decimal>("FirstClassPrice"),
                    EconomyClassPrice = dataRow.Field<decimal>("EconomyClassPrice"),
                    IsAvailable = dataRow.Field<bool>("IsAvailable"),
                    PlaneType = dataRow.Field<string>("PlaneType"),
                    NoRow_FirstClass = dataRow.Field<short>("NoRow_FirstClass"),
                    NoCol_FirstClass = dataRow.Field<short>("NoCol_FirstClass"),
                    NoRow_EcoClass = dataRow.Field<short>("NoRow_EcoClass"),
                    NoCol_EcoClass = dataRow.Field<short>("NoCol_EcoClass"),
                    FirstClassCapacity = dataRow.Field<int?>("FirstClassCapacity"),
                    EcoClassCapacity = dataRow.Field<int?>("EcoClassCapacity"),
                }).ToList() : null;

            return flightAndPlaneDetails;
        }

        public bool InsertFlightDetails(FlightAndPlaneDetailDao flightAndPlaneDetailDao)
        {
            string message;
            var isInsertSuccess = false;
            var updateFlightQueryString = @"INSERT INTO FlightDetails (Id ,FlightNo ,PlaneId ,DepartureAirport ,ArrivalAirport ,DepartureTime ,ArrivalTime
                                            , FirstClassPrice, EconomyClassPrice, IsAvailable, DateCreated, DateModified, FirstClassCapacity, EcoClassCapacity) 
                                             VALUES (@Id ,@FlightNo ,@PlaneId ,@DepartureAirport ,@ArrivalAirport ,@DepartureTime ,@ArrivalTime
                                            , @FirstClassPrice, @EconomyClassPrice, @IsAvailable, @DateCreated, @DateModified, @FirstClassCapacity, @EcoClassCapacity)";

            //var udatePlaneQueryString = @"INSERT INTO PlaneDetails (Id ,Type , NoRow_FirstClass, NoCol_FirstClass
            //                                , NoRow_EcoClass, NoCol_EcoClass, DateCreated, DateModified)  
            //                                , VALUES (@Id ,@Type , @NoRow_FirstClass, @NoCol_FirstClass
            //                                , @NoRow_EcoClass, @NoCol_EcoClass, @DateCreated, @DateModified)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                
                var command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = updateFlightQueryString;
                    command.Parameters.AddWithValue("@Id", Guid.NewGuid());
                    command.Parameters.AddWithValue("@FlightNo", flightAndPlaneDetailDao.FlightNo);
                    command.Parameters.AddWithValue("@PlaneId", flightAndPlaneDetailDao.PlaneId);
                    command.Parameters.AddWithValue("@DepartureAirport", flightAndPlaneDetailDao.DepartureAirport);
                    command.Parameters.AddWithValue("@ArrivalAirport", flightAndPlaneDetailDao.ArrivalAirport);
                    command.Parameters.AddWithValue("@DepartureTime", flightAndPlaneDetailDao.DepartureTime);
                    command.Parameters.AddWithValue("@ArrivalTime", flightAndPlaneDetailDao.ArrivalTime);
                    command.Parameters.AddWithValue("@FirstClassPrice", flightAndPlaneDetailDao.FirstClassPrice);
                    command.Parameters.AddWithValue("@EconomyClassPrice", flightAndPlaneDetailDao.EconomyClassPrice);
                    command.Parameters.AddWithValue("@IsAvailable", flightAndPlaneDetailDao.IsAvailable);
                    if(flightAndPlaneDetailDao.FirstClassCapacity != null)
                    {
                        command.Parameters.AddWithValue("@FirstClassCapacity", flightAndPlaneDetailDao.FirstClassCapacity);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@FirstClassCapacity", DBNull.Value);
                    }
                    if (flightAndPlaneDetailDao.EcoClassCapacity != null)
                    {
                        command.Parameters.AddWithValue("@EcoClassCapacity", flightAndPlaneDetailDao.EcoClassCapacity);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@EcoClassCapacity", DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                    command.Parameters.AddWithValue("@DateModified", DateTime.Now);

                    int flightResult = command.ExecuteNonQuery();

                    //if (planeResult == 1 && flightResult == 1)
                    if (flightResult == 1)
                    {
                        message = flightAndPlaneDetailDao.FlightNo + " Details inserted successfully";
                        isInsertSuccess = true;
                    }
                    else
                    {
                        message = flightAndPlaneDetailDao.FlightNo + " Details not inserted successfully";
                        isInsertSuccess = false;
                    }

                    transaction.Commit();
                }
                catch (SqlException sqlError)
                {
                    transaction.Rollback();
                    isInsertSuccess = false;
                }
            }

            return isInsertSuccess;
        }
    }
}
