using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductDal : EfEntityRepositoryBase<Product, ShopContext>, IProductDal
    {
        public List<ProductDTO> GetAllProduct()
        {
            using (ShopContext context = new())
            {
                var products = context.Products.Include(x=>x.Category).Include(x => x.ProductPicture).ToList();
                var productPictures = context.ProductPicture.Where(x => x.ProductId == 1).ToList();
                List<ProductDTO> result = new();
                

                

                for (int i = 0; i < products.Count; i++)
                {
                    List<string> pictures = new();
                    foreach (var item in productPictures.Where(x => x.ProductId == products[i].Id))
                    {
                        pictures.Add(item.PhotoUrl);
                    }
                    ProductDTO productList = new()
                    {
                        Id = products[i].Id,
                        Name = products[i].Name,
                        Description = products[i].Description,
                        CategoryName = products[i].Category.Name,
                        Price = products[i].Price,
                        SKU = products[i].SKU,
                        Summary = products[i].Summary,
                        ProductPictures = pictures,

                    };
                    result.Add(productList);
                }


                

                return result; 

            }
        }
    }
}
