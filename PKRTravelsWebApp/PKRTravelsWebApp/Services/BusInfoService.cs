using Dapper;
using PKRTravelsWebApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace PKRTravelsWebApp.Services
{
    public class BusInfoService : IBusInfoService
    {
        private readonly IConfiguration _configuration;

        public BusInfoService(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DBConnection");
            provideName = "System.Data.SqlClient";
        }

        public string ConnectionString { get; }
        public string provideName { get; }

        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }




        public List<BusInfo> GetBusInfoList()
        {
            List<BusInfo> busInfos = new List<BusInfo>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    busInfos = dbConnection.Query<BusInfo>("GetBusList", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return busInfos;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return busInfos;
            }
        }

        public string InsertBusInfo(BusInfo busInfo)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var bus = dbConnection.Query<BusInfo>("InsertBusInfo",
                        new { BoardingPoint = busInfo.BoardingPoint, Amount = busInfo.Amount, Rating = busInfo.Rating }, commandType: CommandType.StoredProcedure);

                    if (bus != null )
                    {
                       /* && bus.FirstOrDefault().Response == "Save Successfully!"*/
                        result = "Save Successfully!";
                    }
                    dbConnection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return errorMsg;
            }
        }
    }
}
