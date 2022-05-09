using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDal _productDal;   

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(AddProductDTO productDTO)
        {
            Product product = new()
            {
                Name = productDTO.Name,
                CategoryId = productDTO.CategoryId,
                Description = productDTO.Description,
                Price = productDTO.Price,
                SKU = productDTO.SKU,
                Summary = productDTO.Summary
            };

            _productDal.Add(product);
        }

        public List<ProductDTO> GetAllProductList()
        {
            return _productDal.GetAllProduct();
        }

        public List<Product> GetAllProducts()
        {
            return _productDal.GetAll();
        }

        public ProductDTO GetProductById(int id)
        {
            return _productDal.FindById(id);
        }

        public void Remove(Product product)
        {
            _productDal.Delete(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }

}
