using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBankCRUD.Server.Data
{
    public class DbConnectionRepository
    {
        private readonly IConfiguration _configuration;
        protected readonly string _connection;
        public DbConnectionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = configuration.GetConnectionString("DbConn");
        }
    }
}
