using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Shop;

//public class BookStoreDataSeederContributor
//    : IDataSeedContributor, ITransientDependency
//{
//    private readonly IRepository<Product, Guid> _bookRepository;

//    public BookStoreDataSeederContributor(IRepository<Product, Guid> bookRepository)
//    {
//        _bookRepository = bookRepository;
//    }

//    public async Task SeedAsync(DataSeedContext context)
//    {
//        if (await _bookRepository.GetCountAsync() <= 0)
//        {
//            await _bookRepository.InsertAsync(
//                new Product
//                {
//                    Name = "1984",
//                    Code = "p001",
//                    PurchasePrice = 150,
//                    SalePrice = 250
//                },
//                autoSave: true
//            );

//            await _bookRepository.InsertAsync(
//                new Product
//                {
//                    Name = "Math",
//                    Code = "p002",
//                    PurchasePrice = 250,
//                    SalePrice = 350
//                },
//                autoSave: true
//            );
//        }
//    }
//}