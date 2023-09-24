using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;

namespace Application.Services
{
    public class ProducerService
    {
        private readonly ProducerRepository _producerRepository;

        public ProducerService(ApplicationContext dbcontext)
        {
            _producerRepository = new ProducerRepository(dbcontext);
        }

        public async Task Add(SaveProducerViewModel vm)
        {
            Producer producer = new();
            producer.Name = vm.Name;

            await _producerRepository.AddAsync(producer);
        }

        public async Task Update(SaveProducerViewModel vm)
        {
            Producer producer = new();
            producer.Id = vm.Id;
            producer.Name = vm.Name;

            await _producerRepository.UpdateAsync(producer);
        }

        public async Task Delete(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            await _producerRepository.DeleteAsync(producer);
        }

        public async Task<SaveProducerViewModel> GetByIdSaveViewModel(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);

            SaveProducerViewModel vm = new();
            {
                vm.Id = producer.Id;
                vm.Name = producer.Name;
            }

            return vm;
        }

        public async Task<List<ProducerViewModel>> GetAllViewModel()
        {
            var producerList = await _producerRepository.GetAllAsync();
            return producerList.Select(producer => new ProducerViewModel
            {
                Id = producer.Id,
                Name = producer.Name

            }).ToList();
        }
    }
}
