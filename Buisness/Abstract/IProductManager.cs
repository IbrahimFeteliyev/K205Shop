using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IProductManager
    {
        List<Product> GetAllProducts();
        ProductDTO GetProductById(int id);
        List<ProductDTO> GetAllProductList();
        void Add(AddProductDTO product);
        void Remove(Product product);
        void Update(Product product);
    }
}
