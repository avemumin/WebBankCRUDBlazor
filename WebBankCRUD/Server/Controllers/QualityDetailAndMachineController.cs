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
    public class QualityDetailAndMachineController : ControllerBase
    {
        private readonly QualityDetailReportAndMachineDTORepository _reposityory;

        public QualityDetailAndMachineController(QualityDetailReportAndMachineDTORepository reposityory)
        {
            _reposityory = reposityory ?? throw new ArgumentNullException(nameof(reposityory));
        }


        [HttpGet("{idQual}/{idCur}/{start}/{end}")]
        public async Task<List<QualityDetailReportAndMachineDTO>> Get(short idQual, short idCur, DateTime start, DateTime end)
        {
            return await _reposityory.GetAllFiltered(idQual, idCur, start, end);
        }
    }
}