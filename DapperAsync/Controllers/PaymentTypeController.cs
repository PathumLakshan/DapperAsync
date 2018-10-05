using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;
using DapperAsync.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperAsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private IRepoPayment_Type _iRepoPtype;

        public PaymentTypeController(IRepoPayment_Type iRepoPtype)
        {
            _iRepoPtype = iRepoPtype;
        }

        // GET: api/PaymentType
        [HttpGet]
        public List<Payment_Type> Get()
        {
            return _iRepoPtype.GetPayment_Types();
        }

        /*// GET: api/PaymentType/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/PaymentType
        [HttpPost]
        public int Post([FromBody] Payment_Type payment_Type)
        {
            return _iRepoPtype.NewPayment_Type(payment_Type);
        }

        // PUT: api/PaymentType/5
        [HttpPut]
        public int Put([FromBody]  Payment_Type payment_Type)
        {
            return _iRepoPtype.updatePayment_Type(payment_Type);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepoPtype.deletePaymet_Type(id);
        }
    }
}
