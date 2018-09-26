using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;
using DapperAsync.Repositories.IRepositories;
using GenericRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperAsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IRepoPayment _icontext;

        public PaymentsController(IRepoPayment icontext)
        {
            _icontext = icontext;
        }

        [HttpGet]
        public IEnumerable<Payment> GetAll()
        {
            return _icontext.GetPayments();
        }

        [HttpPost]
        public int Post([FromBody] Payment payment)
        {
            return _icontext.NewPayment(payment);
        }

        [HttpPut]
        public int Put([FromBody] Payment payment)
        {
            return _icontext.updatePayment(payment);
        }
    }
}