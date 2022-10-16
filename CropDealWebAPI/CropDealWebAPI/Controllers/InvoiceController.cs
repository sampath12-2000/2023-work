using Microsoft.AspNetCore.Mvc;
using CropDealWebAPI.Models;
using CropDealWebAPI.Services;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        public readonly InvoiceService _invoiceService;
        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        #region GetById
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)   // working
        {
           
                var invoice = await _invoiceService.GetById(id);
                if (invoice == null)
                {
                    return NotFound();
                }
                return Ok(invoice);
            
        }

        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Invoice invoice)  // not working in swagger but working in postman
        {
            try
            {
                await _invoiceService.Edit(invoice);
                await _invoiceService.Save();
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)  
        {
           
                await _invoiceService.Delete(id);
                return Ok();
           
        }
        #endregion
    }
}
