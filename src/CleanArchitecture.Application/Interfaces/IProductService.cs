using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);

        Task<ProductDTO> GetProductCategoryAsync(int? id);
        Task AddAsync(ProductDTO productDto);
        Task UpdateAsync(ProductDTO productDto);
        Task RemoveAsync(int? id);
    }
}
