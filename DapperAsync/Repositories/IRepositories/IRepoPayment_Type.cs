using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;

namespace DapperAsync.Repositories.IRepositories
{
   public interface IRepoPayment_Type
    {
        List<Payment_Type> GetPayment_Types();
        int NewPayment_Type(Payment_Type payment_Type);
        int updatePayment_Type(Payment_Type payment_Type);
        int deletePaymet_Type(int id);
    }
}
