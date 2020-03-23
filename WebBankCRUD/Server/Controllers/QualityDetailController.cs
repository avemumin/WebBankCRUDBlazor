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
    public class QualityDetailController : ControllerBase
    {
        private readonly QualityDetailReportDTORepository _reposityory;

        public QualityDetailController(QualityDetailReportDTORepository reposityory)
        {
            _reposityory = reposityory ?? throw new ArgumentNullException(nameof(reposityory));
        }


        [HttpGet("{idQual}/{idCur}/{start}/{end}")]
        public async Task<List<QualityDetailReportDTO>> Get(short idQual, short idCur, DateTime start, DateTime end)
        {
            return await _reposityory.GetAllFiltered(idQual, idCur, start, end);
        }
    }
}