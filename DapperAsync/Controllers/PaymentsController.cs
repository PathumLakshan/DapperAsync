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
        private readonly IRepoPayment _iRepoPayment;

        public PaymentsController(IRepoPayment iRepoPayment)
        {
            _iRepoPayment = iRepoPayment;
        }

        [HttpGet]
        public IEnumerable<dynamic> GetAll()
        {
            return _iRepoPayment.GetPayments();
        }

        [HttpPost]
        public int Post([FromBody] Payment payment)
        {
            return _iRepoPayment.NewPayment(payment);
        }

        [HttpPut]
        public int Put([FromBody] Payment payment)
        {
            return _iRepoPayment.updatePayment(payment);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepoPayment.deletePayment(id);
        }
    }
}