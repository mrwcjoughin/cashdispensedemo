using System;
using Microsoft.AspNetCore.Mvc;

using cashdispenseddemoxamarin.Models;

namespace cashdispenseddemoxamarin.Controllers
{
    [Route("api/[controller]")]
    public class CashDispenseResultController : Controller
    {
        private readonly ICashDispenseResultRepository _CashDispenseResultRepository;

        public CashDispenseResultController(ICashDispenseResultRepository CashDispenseResultRepository)
        {
            _CashDispenseResultRepository = CashDispenseResultRepository;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_CashDispenseResultRepository.GetAll());
        }

        [HttpGet("{Id}")]
        public CashDispenseResult GetCashDispenseResult(string id)
        {
            CashDispenseResult CashDispenseResult = _CashDispenseResultRepository.Get(id);
            return CashDispenseResult;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CashDispenseResult CashDispenseResult)
        {
            try
            {
                if (CashDispenseResult == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                _CashDispenseResultRepository.Add(CashDispenseResult);

            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(CashDispenseResult);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] CashDispenseResult CashDispenseResult)
        {
            try
            {
                if (CashDispenseResult == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                _CashDispenseResultRepository.Update(CashDispenseResult);
            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public void Delete(string id)
        {
            _CashDispenseResultRepository.Remove(id);

        }
    }
}
