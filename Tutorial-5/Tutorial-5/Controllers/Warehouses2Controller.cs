using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_5.Models;
using static Tutorial_5.Services.WarehouseMainService;


namespace Tutorial_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Warehouses2Controller : ControllerBase
    {
        private IDatabaseService _dbService;

        public Warehouses2Controller(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public IActionResult CreateProductWarehouse(Warehouse warehouse)
        {
            _dbService.createProductWarehouseWithProcedure(warehouse.IdProduct, warehouse.IdWarehouse, warehouse.Amount, warehouse.CreatedAt);
            return Created("", "Record inserted with ID = " + _dbService.getProductWarehouseID(warehouse.IdProduct, warehouse.IdWarehouse, warehouse.Amount));
        }
    }
}
