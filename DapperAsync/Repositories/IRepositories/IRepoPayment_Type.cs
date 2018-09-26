using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;

namespace DapperAsync.Repositories.IRepositories
{
    interface IRepoPayment_Type
    {
        List<Payment_Type> GetPayment_Types();
        int NewPayment_Type(Payment_Type payment_Type);
        bool updatePayment_Type(Payment_Type payment_Type);
    }
}
