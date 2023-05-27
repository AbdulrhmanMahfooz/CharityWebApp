

using System;
using CharityApp.Models;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CharityApp.Models.Countries;
using System.Data.Entity;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using CharityApp.EndwomentData;
using System.Diagnostics;
using CharityApp.Models.Currencies;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CharityApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CurrenciesController : ControllerBase
    {
        private readonly EndowmentDbContext _endowmentContex;
        public CurrenciesController(EndowmentDbContext EndowmentDbContext)
        {
            _endowmentContex = EndowmentDbContext;
        }



        // adding and eediting Currency EndPoint
        [HttpPost("add_edit_currency")]
        public async Task<IActionResult> add_edit_currency(add_edit_currency_Req addEditRequest)
        {


            if (addEditRequest.currenyId != 0)
            {
                // edit 
                var currency = await _endowmentContex.Currencies
                    .Where(x => x.CurrencyNo == addEditRequest.currenyId)
                    .FirstOrDefaultAsync();


                currency.CurrencyName = addEditRequest.currencyArName;
                currency.CurrencyShortNameLatin = addEditRequest.currencyEnName;
                currency.DateOpen = addEditRequest.createdAt;
                currency.Remarks = addEditRequest.notes;
                currency.Stop = addEditRequest.isActivate;
                currency.CurrencyShortName = addEditRequest.arCode;
                currency.CurrencyShortNameLatin = addEditRequest.enCode;
                _endowmentContex.Currencies.Update(currency);
            }
            else
            {
                // add 
                var AddEditCurrency = new EndwomentData.Currency
                {
                    CurrencyName = addEditRequest.currencyArName,
                    CurrencyNameLatin = addEditRequest.currencyEnName,
                    DateOpen = addEditRequest.createdAt,
                    Stop = addEditRequest.isActivate,
                    Remarks = addEditRequest.notes,
                    Rate= addEditRequest.convertionRate,
                    CurrencyShortName = addEditRequest.arCode,
                    CurrencyShortNameLatin  = addEditRequest.enCode,

                };

                await _endowmentContex.Currencies.AddAsync(AddEditCurrency);


            };

            var AddEditCurrencyRef = new EndwomentData.CurrenciesRef
            {
                CurrencyName = addEditRequest.currencyArName,
                CurrencyNameLatin = addEditRequest.currencyEnName,
                DateOpen = addEditRequest.createdAt,
                Stop = addEditRequest.isActivate,
                Remarks = addEditRequest.notes,
                Rate = addEditRequest.convertionRate,
                CurrencyShortName = addEditRequest.arCode,
                CurrencyShortNameLatin = addEditRequest.enCode,
            };
            await _endowmentContex.CurrenciesRefs.AddAsync(AddEditCurrencyRef);


            await _endowmentContex.SaveChangesAsync();

            var Res = new add_edit_currencey_Res
            {
                data = new Models.Currencies.Data
                {
                    currenyId = addEditRequest.currenyId,
                    currencyArName = addEditRequest.currencyArName,
                    currencyEnName = addEditRequest.currencyEnName,
                    createdAt = addEditRequest.createdAt,
                    convertionRate = addEditRequest.convertionRate,
                    arCode = addEditRequest.arCode,
                    enCode = addEditRequest.enCode,
                    notes = addEditRequest.notes,
                    isActivate = addEditRequest.isActivate,
                   
                    
                }
            };


            return Ok(Res);

        }

        // Delete Currency
        [HttpPost("Delete_Currency")]
        public async Task<IActionResult> Delete_Currency(delete_currencey_Req delete_Currencny)
        {

            var currency = await _endowmentContex.Currencies
                .Where(x => x.CurrencyNo == delete_Currencny.currenyId)
                .FirstOrDefaultAsync();

            if (currency != null)
            {
                _endowmentContex.Currencies.Remove(currency);
                await _endowmentContex.SaveChangesAsync();
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }




        // Get Currecny BY ID 
        [HttpPost("Get_Currecny_BY_ID")]
        public async Task<IActionResult> Get_Currency_By_ID(get_currencey_Res currrency_req)  // Delete_Country class is Used becaue it has same request attribute
        {


            var currency = await _endowmentContex.Currencies
                   .Where(x => x.CurrencyNo == currrency_req.currenyId)
                   .FirstOrDefaultAsync();

            if (currency != null)
            {

                var Res = new add_edit_currencey_Res
                {
                    data = new Models.Currencies.Data
                    {
                        currenyId = currency.CurrencyNo,
                        currencyArName = currency.CurrencyName,
                        currencyEnName = currency.CurrencyNameLatin,
                        createdAt = currency.DateOpen,
                        convertionRate = (double)currency.Rate,
                        arCode = currency.CurrencyShortName,
                        enCode = currency.CurrencyNameLatin,
                        notes = currency.Remarks,
                        isActivate = (bool)currency.Stop,
                    }
                };
                return Ok(Res);
            }
            else
            {
                return Ok(false);
            }


        }


    }
}
