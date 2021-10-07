using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class WarehousesController : ControllerBase
    {
        private IDatabaseService _dbService;

        public WarehousesController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public IActionResult CreateProductWarehouse(Warehouse warehouse)
        {
            if (_dbService.productExists(warehouse.IdProduct)
              && _dbService.warehouseExists(warehouse.IdWarehouse)
              && warehouse.Amount > 0)
            {
                if (_dbService.checkOrder(warehouse.IdProduct, warehouse.Amount)
                  && _dbService.checkDate(warehouse.CreatedAt, warehouse.IdProduct, warehouse.Amount))
                {
                    if (_dbService.checkCompletedOrder(warehouse.IdProduct, warehouse.Amount))
                    {
                        _dbService.updateFullfilledAt(warehouse.IdProduct, warehouse.Amount);
                        return Created("","Record inserted with ID = " + _dbService.createProductWarehouse(warehouse.IdProduct, warehouse.IdWarehouse, warehouse.Amount));
                    }
                         else return BadRequest("The order has already been completed.");
                }
                else return NotFound("There is no suitable order.");
            }
            else return NotFound("The product/warehouse with the given id does not exist");
        }
    }
}

