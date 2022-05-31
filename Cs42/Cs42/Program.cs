using System;
using Cs42.Domain.UnitOfWork;

namespace Cs42
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
