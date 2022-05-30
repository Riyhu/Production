using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Production.Contracts;
using Production.Entities.DTO;
using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductionWebApi.Controllers
{
    [Route("api/workorder")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public WorkOrderController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IServiceManager serviceManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _serviceManager = serviceManager;
            _mapper = mapper;
        }


        [HttpPost("productinfo")]
        public async Task<IActionResult> PostWorkOrder([FromBody] ProductWorkOrderDTO productWorkOrderDTO)
        {
            var productWorkOrder = await _serviceManager.AddProductInformation(productWorkOrderDTO);
            return Ok(productWorkOrder);
            
        }

        [HttpPost("order")]
        public async Task<IActionResult> PostProductWorkOrder([FromBody] WorkOrderDTO workOrderDTO)
        {
            var workOrder = await _serviceManager.AddtoOrder(workOrderDTO);
            return Ok(workOrder);
        }
        [HttpGet]
        public async Task<IActionResult> GetRouting()
        {
            try
            {
                var routings = await _serviceManager.GetAllOrderRouting(trackChanges: false);
                return Ok(_mapper.Map<IEnumerable<WorkOrderRoutingDTO>>(routings));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
