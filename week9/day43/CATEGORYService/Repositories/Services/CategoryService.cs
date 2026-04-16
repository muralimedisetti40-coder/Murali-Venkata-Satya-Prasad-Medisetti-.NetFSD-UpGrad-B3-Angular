using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _repo.AddAsync(category);
        }

        public async Task UpdateAsync(int id, Category category)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return;

            existing.CategoryName = category.CategoryName;
            existing.Description = category.Description;

            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}