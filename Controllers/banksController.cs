using CharityApp.Models;
using CharityApp.EndwomentData;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class banksController : ControllerBase
    {
        private readonly EndowmentDbContext _endowmentContex;
        public banksController(EndowmentDbContext EndowmentDbContext)
        {
            _endowmentContex = EndowmentDbContext;
        }
        //Get Bank By ID
        [HttpPost("get_bank_by_id")]

        public async Task<IActionResult> getBank(getBankByIdRequest getBank)
        {
            List<Bank> banks = await _endowmentContex.Banks.Where(x => x.BankNo == getBank.bankId).ToListAsync();

            List<getBankByIdResponse> testc = banks.Select(r => new getBankByIdResponse
            {

                bankId = r.BankNo,
                bankArName = r.BankName,
                bankEnName = r.BankNameLatin,
                isActivated = (bool)r.Stop,
                createdAt = r.OriginDate,
                notes = r.Remarks

            }).ToList();
            return Ok(testc);
        }

        //Add Bank Endpoint
        [HttpPost("add_bank")]
        public async Task<IActionResult> addBank(addBankRequest add)
        {
            if (add.bankId == 0)
            {
                var addBank = new EndwomentData.Bank
                {
                    BankNo = (short)add.bankId,

                    BankName = add.bankArName,
                    BankNameLatin = add.bankEnName,
                    OriginDate = add.createdAt,
                    Remarks = add.notes,
                    Stop = add.isActivated

                };
                var addBanksRef = new EndwomentData.BanksRef
                {
                    BankNo = (short)add.bankId,
                    BankName = add.bankArName,
                    BankNameLatin = add.bankEnName,
                    OriginDate = add.createdAt,
                    Remarks = add.notes,
                    Stop = add.isActivated

                };

                await _endowmentContex.Banks.AddAsync(addBank);
                await _endowmentContex.BanksRefs.AddAsync(addBanksRef);
                await _endowmentContex.SaveChangesAsync();

                return Ok(addBank);
            }
            else
            {
                var bank = await _endowmentContex.Banks
                    .Where(x => x.BankNo == add.bankId)
                    .FirstOrDefaultAsync();


                bank.BankNo = (short)add.bankId;
                bank.BankName = add.bankArName;
                bank.BankNameLatin = add.bankEnName;
                bank.OriginDate = add.createdAt;
                bank.Remarks = add.notes;
                bank.Stop = add.isActivated;


                var addBanksRef = new EndwomentData.BanksRef
                {

                    BankNo = bank.BankNo,
                    BankName = bank.BankName,
                    BankNameLatin = bank.BankNameLatin,
                    OriginDate = bank.OriginDate,
                    Remarks = bank.Remarks,
                    Stop = bank.Stop

                };


                await _endowmentContex.BanksRefs.AddAsync(addBanksRef);
                await _endowmentContex.SaveChangesAsync();
                return Ok(bank);
            }

        }


        // Delete Bank Endpoint
        [HttpPost("delete_banks")]
        public async Task<IActionResult> deleteBank(deleteBankRequest DeBank)
        {
            var bank = await _endowmentContex.Banks
            .Where(x => x.BankNo == DeBank.bankId)
            .FirstOrDefaultAsync();
            var delete = new deleteBankResponse
            {
                result = true
            };

            var addBankRef = new EndwomentData.BanksRef
            {
                BankNo = bank.BankNo,
                BankName = bank.BankName,
                BankNameLatin = bank.BankNameLatin,
                OriginDate = bank.OriginDate,
                Remarks = bank.Remarks,
                Stop = bank.Stop,
            };

            await _endowmentContex.BanksRefs.AddAsync(addBankRef);
            _endowmentContex.Banks.Remove(bank);
            await _endowmentContex.SaveChangesAsync();
            return Ok(true);

        }
    }
}