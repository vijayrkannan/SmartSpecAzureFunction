using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using SmartSpaceFunction.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartSpaceFunction.Utlities
{
    public class SqlHelper
    {
        public static readonly string _SqlConnectionString = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);
        public static readonly string _UserName = Environment.GetEnvironmentVariable("SqlLogin", EnvironmentVariableTarget.Process);
        public static readonly string _Password = Environment.GetEnvironmentVariable("SqlPassword", EnvironmentVariableTarget.Process);
        public static List<Location> excuteQueryandReturnResult(string query, string paramvalue, ILogger log, ExecutionContext context)
        {
            List<Location> sqlResult = new List<Location>();

            string sqlcon = _SqlConnectionString.Replace("{UId}", _UserName).Replace("{PW}", _Password);

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlcon))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            cmd.CommandTimeout = 100;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Json", paramvalue);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                List<Position> pts = new List<Position>();
                                Location lt = new Location();
                                lt.Address = new Address(row["Number"].ToString(),row["Street"].ToString()
                                                        ,row["City"].ToString(), row["State"].ToString()
                                                        , row["ZipCode"].ToString());
                                lt.BuildingFunction = row["BuildingFunction"].ToString();
                                lt.BuildingNumber = row["BuildingNumber"].ToString();
                                lt.Capacity = Convert.ToInt32(row["Capacity"]);
                                lt.Name = row["BuildingName"].ToString();
                                lt.NumberOfFloors = Convert.ToInt32(row["NumberOfFloors"]);

                                foreach (dynamic jObject in JArray.Parse(string.Concat("[", row["Position"].ToString(),"]")))
                                {
                                    Position pt = new Position((double)jObject.Latitude, (double)jObject.Longitude);
                                    pts.Add(pt);
                                   // lt.Positions.Add(pt);
                                }
                                lt.Positions = pts;
                                sqlResult.Add(lt);

                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                log.LogInformation(string.Format("Msg = {0}",e.Message));
            }

            return sqlResult;
        }
    }
}
