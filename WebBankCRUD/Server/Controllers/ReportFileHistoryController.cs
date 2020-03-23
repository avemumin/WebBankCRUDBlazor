using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBankCRUD.Server.Data;
using WebBankCRUD.Shared.ModelsDTO;

namespace WebBankCRUD.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportFileHistoryController : ControllerBase
    {
        private readonly ReportFileHistoryRepository _reposityory;

        public ReportFileHistoryController(ReportFileHistoryRepository reposityory)
        {
            _reposityory = reposityory ?? throw new ArgumentNullException(nameof(reposityory));
        }

        [HttpGet]
        public async Task<List<FileHistoryDTO>> Get()
        {
            return await _reposityory.GetAll();
        }


        [HttpGet("{start}/{end}")]
        public async Task<List<FileHistoryDTO>> GetByDate(DateTime start, DateTime end)
        {
            return await _reposityory.GetAllInDate(start, end);
        }
    }
}