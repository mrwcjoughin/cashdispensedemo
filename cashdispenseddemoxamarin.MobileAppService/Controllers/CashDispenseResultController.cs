﻿using System;
using Microsoft.AspNetCore.Mvc;

using Models;

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
		public IActionResult PostCashDispenseResult([FromBody]CashDispenseResult cashDispenseResult)
		{
            if (decimal.Parse(cashDispenseResult.CashHandedOver.Number) < decimal.Parse(cashDispenseResult.CashDispenseDue.AmountOwed.Number))
			{
				return BadRequest("The amount you are paying is less than the amount owed");
			}

			//CashDispenseResult cashDispenseResult = new CashDispenseResult();

            var difference = decimal.Parse(cashDispenseResult.CashHandedOver.Number) - decimal.Parse(cashDispenseResult.CashDispenseDue.AmountOwed.Number);

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

            _cashDispenseResultRepository.Add(cashDispenseResult);

			return Ok(cashDispenseResult);
		}

		private static decimal Calc(decimal number, string denomination, CashDispenseResult cashDispenseResult, decimal runningDifference)
		{
            var randNoteResults = runningDifference / number;

			if (randNoteResults >= 1)
			{
                ChangeResult changeResult = new ChangeResult();

				changeResult.Cash = new Cash();
				changeResult.Cash.Denomination = denomination;
				changeResult.Cash.Number = number.ToString();
                changeResult.Quantity = (short)(Math.Abs(randNoteResults));

				cashDispenseResult.ChangeResults.Add(changeResult);

				runningDifference -= (decimal)changeResult.Quantity * number;
			}

			return runningDifference;
		}
    }
}