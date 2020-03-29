using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebBankCRUD.Server.Models;
using WebBankCRUD.Shared.ModelsDTO;

namespace WebBankCRUD.Server.Data
{
    public class ReportFileHistoryRepository : DbConnectionRepository
    {
        //private readonly IConfiguration _configuration;
        public ReportFileHistoryRepository(IConfiguration configuration):base(configuration)
        {
           // _configuration = configuration;
        }
        public async Task<List<FileHistoryDTO>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand("SelectAllReportFileHistory2", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var response = new List<FileHistoryDTO>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    } 
                    //na wszelki wypadek tylko 20
                    return response.OrderByDescending(x=>x.IdFileHistory).Take(20).ToList();
                }
            }
        }

        private FileHistoryDTO MapToValue(SqlDataReader reader)
        {
            return new FileHistoryDTO()
            {
                IdFileHistory = (long)reader["IdFileHistory"],
                FileName = (string)reader["FileName"],
                IsProceededSuccess = (bool)reader["IsProceededSuccess"],
                ErrorDescription = (string)reader["ErrorDescription"],
                ProcessDate = (DateTime)reader["ProcessDate"],
                IdCountResult = Convert.IsDBNull(reader["IdCountResult"]) ? null : (long?)reader["IdCountResult"]
            };
        }
        public Task<List<FileHistoryDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<FileHistoryDTO>> GetAllInDate(DateTime start, DateTime end)
        {
            using (SqlConnection sql = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand("SelectAllReportFileHistory", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@DateFrom", start));
                    cmd.Parameters.Add(new SqlParameter("@DateTo", end));
                    var response = new List<FileHistoryDTO>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

    }
}
