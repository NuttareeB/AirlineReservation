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
    public class BookingDataProvider
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["AirlineConnectionString"].ConnectionString;

        public List<SeatPositionDao> GetOccupiedSeatsFromFlightId(Guid flightId)
        {
            var queryString = @"SELECT SeatRow, SeatCol, Class
                                  FROM BookingDetails
                                  WHERE FlightId = @FlightId";
            var ds = new DataSet();

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    var command = new SqlCommand(queryString, connection);
                    var da = new SqlDataAdapter(command);
                    command.Parameters.AddWithValue("@FlightId", flightId);
                    da.Fill(ds);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException sqlError)
                {

                }
            }

            var seatPositions = ds.Tables.Count != 0 ? ds.Tables[0].AsEnumerable()
                .Select(dataRow => new SeatPositionDao
                {
                    SeatRow = dataRow.Field<short>("SeatRow"),
                    SeatCol = dataRow.Field<short>("SeatCol"),
                    Class = (SeatClass) dataRow.Field<short>("Class")
                }).ToList() : null;

            return seatPositions;
        }

        public string InsertBookingDetails(BookingDetailRequest bookingDetailRequest)
        {
            var insertBookingQueryString = @"INSERT INTO BookingDetails (FlightId ,CustomerId ,SeatRow ,SeatCol ,Class, DateCreated, DateModified) 
                                             OUTPUT Inserted.Id
                                             VALUES (@FlightId ,@CustomerId ,@SeatRow ,@SeatCol ,@Class, @DateCreated, @DateModified)";
            var insertUserQueryString = @"INSERT INTO Users (Username, FirstName, LastName, Age, Role, DateCreated, DateModified) 
                                             OUTPUT Inserted.Id
                                             VALUES (@Username ,@FirstName ,@LastName ,@Age, @Role, @DateCreated, @DateModified)";
            string bookingId = "";
            Guid userId = Guid.Empty;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                var command = connection.CreateCommand();
                command.Transaction = transaction;
                try 
                {
                    command.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                    command.Parameters.AddWithValue("@DateModified", DateTime.Now);
                    if (bookingDetailRequest.BookingDetailDao.CustomerId == Guid.Empty)
                    {
                        //if customer id isn't provided, we will try to get the user data first.
                        //if we cannot find this user, we will create a new user.
                        var userDataProvider = new UserDataProvider();
                        var userData = userDataProvider.GetUserByUsername(bookingDetailRequest.FirstName);
                        if(userData != null)
                        {
                            userId = userData.Id;
                        }
                        else
                        {
                            command.CommandText = insertUserQueryString;
                            command.Parameters.AddWithValue("@Username", bookingDetailRequest.FirstName);
                            command.Parameters.AddWithValue("@FirstName", bookingDetailRequest.FirstName);
                            command.Parameters.AddWithValue("@LastName", bookingDetailRequest.LastName);
                            command.Parameters.AddWithValue("@Age", bookingDetailRequest.Age);
                            command.Parameters.AddWithValue("@Role", Role.User);

                            userId = (Guid)command.ExecuteScalar();
                        }
                    };

                    if(userId != Guid.Empty)
                    {
                        command.CommandText = insertBookingQueryString;
                        command.Parameters.AddWithValue("@FlightId", bookingDetailRequest.BookingDetailDao.FlightId);
                        command.Parameters.AddWithValue("@CustomerId", userId);
                        command.Parameters.AddWithValue("@SeatRow", bookingDetailRequest.BookingDetailDao.SeatRow);
                        command.Parameters.AddWithValue("@SeatCol", bookingDetailRequest.BookingDetailDao.SeatCol);
                        command.Parameters.AddWithValue("@Class", bookingDetailRequest.BookingDetailDao.Class);

                        bookingId = command.ExecuteScalar().ToString();
                    }

                    if (string.IsNullOrEmpty(bookingId))
                    {
                        transaction.Rollback();
                    }

                    transaction.Commit();
                }
                catch (SqlException sqlError)
                {
                    transaction.Rollback();
                }
            }

            return bookingId;
        }
    }
}
