using DapperAsync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Repositories.IRepositories
{
    public interface IRepoPayment
    {
        IEnumerable<dynamic> GetPayments();
        int NewPayment(Payment payment);
        int updatePayment(Payment payment);
        int deletePayment(int id);
    }
}