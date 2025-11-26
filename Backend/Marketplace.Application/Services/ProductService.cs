using AutoMapper;
using Marketplace.Application.DTOs;
using Marketplace.Application.Interfaces.Repositories;
using Marketplace.Application.Interfaces.Services;
using Marketplace.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _dbContext;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository dbcontext, IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            var product = await _dbContext.AddAsync(entity);
            var result = _mapper.Map<ProductDto>(product);
            return result;

        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.DeleteAsync(id);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _dbContext.GetAllAsync();
            var result = products.Select(x=> _mapper.Map<ProductDto>(x)).ToList();
            return result;
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await _dbContext.GetByIdAsync(id);
            var result = _mapper.Map<ProductDto>(product);
            return result;
        }

        public async Task UpdateAsync(Guid id, UpdateProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            entity.Id = id;
            await _dbContext.UpdateAsync(entity);
        }
    }
}
