using ExpenseTrackerAPI.Domain.Entities;
using ExpenseTrackerAPI.Domain.ViewModel;
using ExpenseTrackerAPI.Services.TransactionService;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            try
            {
                var result = await _service.GetAllTransactions();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("InsertTransaction")]
        public async Task<IActionResult> InsertTransaction([FromBody]TransactionViewModel request)
        {
            try
            {
                await _service.InsertTransaction(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] TransactionViewModel request)
        {
            try
            {
                await _service.UpdateTransaction(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTransaction/{idTransaction}")]
        public async Task<IActionResult> DeleteTransaction(uint idTransaction)
        {
            try
            {
                await _service.DeleteTransaction(idTransaction);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetTransactionInfoAnalytics")]
        public async Task<IActionResult> GetTransactionInfoAnalytics()
        {
            try
            {
                var result = await _service.GetTransactionInfoAnalytics();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}