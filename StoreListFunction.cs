using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RESTApiMLFunction
{
    class StoreListFunction
    {
        [FunctionName("CreateStore")]
        public static async Task<IActionResult> CreateStore(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Store")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<CreateStoreModel>(requestBody);
            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    if (String.IsNullOrEmpty(input.Storename))
                    {
                        var query = $"INSERT INTO [ml].[t_store] (Storename,CompanyNo,sysCreateDate) VALUES('{input.Storename}' , '{input.CompanyNo}', '{input.sysCreateDate}')";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
                return new BadRequestResult();
            }
            return new OkResult();
        }

        [FunctionName("GetStores")]
        public static async Task<IActionResult> GetStores(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Store")] HttpRequest req, ILogger log)
        {
            List<StoreModel> StoreList = new List<StoreModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    var query = @"Select * from [ml].[t_store]";
                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        StoreModel Store = new StoreModel()
                        {
                            Storeid = (int)reader["Storeid"],
                            Branchid = (int)reader["Branchid"],
                            Storename = reader["Storename"].ToString(),
                            CompanyNo = reader["CompanyNo"].ToString(),
                            AddressLine1 = reader["AddressLine1"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            District = reader["District"].ToString(),
                            County = reader["County"].ToString(),
                            PostCode = reader["PostCode"].ToString(),
                            Country = reader["Country"].ToString(),
                            Longitude = (int)reader["Longitude"],
                            Latitude = (int)reader["Latitude"],
                            ContactNumber = reader["ContactNumber"].ToString(),
                            ContactNumber2 = reader["ContactNumber2"].ToString(),
                            sysStatus = reader["sysStatus"].ToString(),
                            sysAppliedDate = (DateTime)reader["sysAppliedDate"],
                            sysApprovedDate = (DateTime)reader["sysApprovedDate"],
                            sysModifyDate = (DateTime)reader["sysModifyDate"],
                            sysCreateDate = (DateTime)reader["sysCreateDate"],
                        };
                        StoreList.Add(Store);
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
            if (StoreList.Count > 0)
            {
                return new OkObjectResult(StoreList);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [FunctionName("GetStoreById")]
        public static IActionResult GetStoreById(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Store/{id}")] HttpRequest req, ILogger log, int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    var query = @"Select * from [ml].[t_store] Where Storeid = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
            if (dt.Rows.Count == 0)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(dt);
        }

        [FunctionName("DeleteStore")]
        public static IActionResult DeleteStore(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "Store/{id}")] HttpRequest req, ILogger log, int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    var query = @"Delete from [ml].[t_store] Where Storeid = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
                return new BadRequestResult();
            }
            return new OkResult();
        }

        [FunctionName("UpdateStore")]
        public static async Task<IActionResult> UpdateStore(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Store/{id}")] HttpRequest req, ILogger log, int id)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<UpdateStoreModel>(requestBody);
            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    var query = @"Update [ml].[t_store] Set Storename = @Storename , CompanyNo = @CompanyNo Where Storeid = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Branchid", input.Branchid);
                    command.Parameters.AddWithValue("@Storename", input.Storename);
                    command.Parameters.AddWithValue("@CompanyNo", input.CompanyNo);
                    command.Parameters.AddWithValue("@AddressLine1", input.AddressLine1);
                    command.Parameters.AddWithValue("@AddressLine2", input.AddressLine2);
                    command.Parameters.AddWithValue("@District", input.District);
                    command.Parameters.AddWithValue("@County", input.County);
                    command.Parameters.AddWithValue("@PostCode", input.PostCode);
                    command.Parameters.AddWithValue("@Country", input.Country);
                    command.Parameters.AddWithValue("@Longitude", input.Longitude);
                    command.Parameters.AddWithValue("@Latitude", input.Latitude);
                    command.Parameters.AddWithValue("@ContactNumber", input.ContactNumber);
                    command.Parameters.AddWithValue("@ContactNumber2", input.ContactNumber2);
                    command.Parameters.AddWithValue("@sysStatus", input.sysStatus);
                    command.Parameters.AddWithValue("@sysAppliedDate", input.sysAppliedDate);
                    command.Parameters.AddWithValue("@sysApprovedDate", input.sysApprovedDate);
                    command.Parameters.AddWithValue("@sysModifyDate", input.sysModifyDate);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
            return new OkResult();
        }
    }
}