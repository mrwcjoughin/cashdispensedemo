using System;
using Microsoft.AspNetCore.Mvc;

using cashdispenseddemoxamarin.MobileAppService.Models;

namespace cashdispenseddemoxamarin.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class CashDispenseResultController : Controller
    {
        private readonly ICashDispenseResultRepository _cashDispenseResultRepository;

        public CashDispenseResultController(ICashDispenseResultRepository CashDispenseResultRepository)
        {
            _cashDispenseResultRepository = CashDispenseResultRepository;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_cashDispenseResultRepository.GetAll());
        }

		// GET api/values/cash
		[HttpPost]
		public IActionResult PostCash(Cash cash)
		{
			if (cash.Number < CashDispenseDue.DefaultAmountOwed.Number)
			{
				return BadRequest("The amount you are paying is less than the amount owed");
			}

			CashDispenseResult cashDispenseResult = new CashDispenseResult();

			var difference = cash.Number - CashDispenseDue.DefaultAmountOwed.Number;

			var runningDifference = difference;

			if (runningDifference > 0)
			{
				runningDifference = Calc(100.00m, "R", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(50.00m, "R", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(20.00m, "R", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(10.00m, "R", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(5.00m, "R", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(2.00m, "R", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(1.00m, "R", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(0.50m, "cents", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(0.20m, "cents", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(0.25m, "cents", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(0.10m, "cents", cashDispenseResult, runningDifference);
			}

			if (runningDifference > 0)
			{
				runningDifference = Calc(0.05m, "cents", cashDispenseResult, runningDifference);
			}

			return Ok(cashDispenseResult);
		}

		private static decimal Calc(decimal number, string denomination, CashDispenseResult cashDispenseResult, decimal runningDifference)
		{
			var randNoteResults = runningDifference / number;

			if (randNoteResults >= 1)
			{
				Cash randNotes = new Cash();
				randNotes.Denomination = denomination;
				randNotes.Number = Math.Abs(randNoteResults);

				cashDispenseResult.ChangeResults.Add(randNotes);

				runningDifference -= randNotes.Number * number;
			}

			return runningDifference;
		}

        //[HttpGet("{Id}")]
        //public CashDispenseResult GetCashDispenseResult(string id)
        //{
        //    CashDispenseResult CashDispenseResult = _cashDispenseResultRepository.Get(id);
        //    return CashDispenseResult;
        //}

        //[HttpPost]
        //public IActionResult Create([FromBody]CashDispenseResult CashDispenseResult)
        //{
        //    try
        //    {
        //        if (CashDispenseResult == null || !ModelState.IsValid)
        //        {
        //            return BadRequest("Invalid State");
        //        }

        //        _cashDispenseResultRepository.Add(CashDispenseResult);

        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Error while creating");
        //    }
        //    return Ok(CashDispenseResult);
        //}

        //[HttpPut]
        //public IActionResult Edit([FromBody] CashDispenseResult CashDispenseResult)
        //{
        //    try
        //    {
        //        if (CashDispenseResult == null || !ModelState.IsValid)
        //        {
        //            return BadRequest("Invalid State");
        //        }
        //        _cashDispenseResultRepository.Update(CashDispenseResult);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Error while creating");
        //    }
        //    return NoContent();
        //}

        //[HttpDelete("{Id}")]
        //public void Delete(string id)
        //{
        //    _cashDispenseResultRepository.Remove(id);

        //}
    }
}
