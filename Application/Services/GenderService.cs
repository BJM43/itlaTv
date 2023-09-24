using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;

namespace Application.Services
{
    public class GenderService
    {
        private readonly GenderRepository _genderRepository;

        public GenderService(ApplicationContext dbcontext)
        {
            _genderRepository = new GenderRepository(dbcontext);
        }

        public async Task Add(SaveGenderViewModel vm)
        {
            Gender gender = new();
            gender.Name = vm.Name;

            await _genderRepository.AddAsync(gender);
        }

        public async Task Update(SaveGenderViewModel vm)
        {
            Gender gender = new();
            gender.Id = vm.Id;
            gender.Name = vm.Name;

            await _genderRepository.UpdateAsync(gender);
        }

        public async Task Delete(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);
            await _genderRepository.DeleteAsync(gender);
        }

        public async Task<SaveGenderViewModel> GetByIdSaveViewModel(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);

            SaveGenderViewModel vm = new();
            {
                vm.Id = gender.Id;
                vm.Name = gender.Name;
            }

            return vm;
        }

        public async Task<List<GenderViewModel>> GetAllViewModel()
        {
            var genderList = await _genderRepository.GetAllAsync();
            return genderList.Select(gender => new GenderViewModel
            {
                Id = gender.Id,
                Name = gender.Name

            }).ToList();
        }
    }
}
