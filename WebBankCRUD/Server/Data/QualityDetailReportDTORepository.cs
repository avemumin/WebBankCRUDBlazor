using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebBankCRUD.Shared.ModelsDTO;

namespace WebBankCRUD.Server.Data
{
    public class QualityDetailReportDTORepository:DbConnectionRepository
    {
        public QualityDetailReportDTORepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<QualityDetailReportDTO>> GetAllFiltered(short idQual, short idCur, DateTime start, DateTime end)
        {
            using (SqlConnection sql = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand("CurrencyQualityRepoSp", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idQuality", idQual));
                cmd.Parameters.Add(new SqlParameter("@idCurrency ", idCur));
                cmd.Parameters.Add(new SqlParameter("@startDate ", start));
                cmd.Parameters.Add(new SqlParameter("@endDate ", end));
                var response = new List<QualityDetailReportDTO>();
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
        /// <summary>
        /// Map propety with stored procedure
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private QualityDetailReportDTO MapToValue(SqlDataReader reader)
        {
            return new QualityDetailReportDTO()
            {
                IdCurrencyFaceValue = (short)reader["IdCurrencyFaceValue"],
                FaceValue = (decimal)reader["FaceValue"],
                CountedCount = (int)reader["CountedCount"],
                Count = (int)reader["Counts"],
                QualityValue = (string)reader["QualityValue"],
                Symbol = (string)reader["Symbol"],
                ModeValue=(string)reader["ModeValue"]
            };
        }
    }
}
