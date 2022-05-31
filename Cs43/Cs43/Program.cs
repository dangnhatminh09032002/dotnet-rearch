using System;
using Cs43.Domain.UnitOfWork;

namespace Cs43
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork.DropDatabase();
            UnitOfWork.CreateDatabase();
            UnitOfWork.InsertCatogory();
            UnitOfWork.InsertProduct();
            UnitOfWork.ShowProduct();
        }
    }
}
