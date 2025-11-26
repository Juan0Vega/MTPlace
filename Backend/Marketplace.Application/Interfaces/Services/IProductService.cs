using Marketplace.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Application.Interfaces.Services
{
    public interface IProductService
    {

        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task<List<ProductDto>> GetAllAsync();
        Task UpdateAsync(Guid id, UpdateProductDto dto);
        Task DeleteAsync(Guid id);

    }
}
