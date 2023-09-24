using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;

namespace Application.Services
{
    public class TvSerieService
    {
        private readonly SerieRepository _tvSerieRepository;

        public TvSerieService(ApplicationContext dbcontext)
        {
            _tvSerieRepository = new SerieRepository(dbcontext);
        }

        public async Task Add(SaveTvSerieViewModel vm)
        {
            TvSerie serie = new();
            serie.Name = vm.Name;
            serie.Link = vm.Link;
            serie.ImgLink = vm.ImgLink;
            serie.ProducerId = vm.ProducerId;
            serie.GenderId = vm.GenderId;

            await _tvSerieRepository.AddAsync(serie);
        }

        public async Task Update(SaveTvSerieViewModel vm)
        {
            TvSerie serie = new();
            serie.Id = vm.Id;
            serie.Name = vm.Name;
            serie.Link = vm.Link;
            serie.ImgLink = vm.ImgLink;
            serie.ProducerId = vm.ProducerId;
            serie.GenderId = vm.GenderId;

            await _tvSerieRepository.UpdateAsync(serie);
        }

        public async Task Delete(int id)
        {
            var tvserie = await _tvSerieRepository.GetByIdAsync(id);
            await _tvSerieRepository.DeleteAsync(tvserie);
        }

        public async Task<SaveTvSerieViewModel> GetByIdSaveViewModel(int id)
        {
            var tvserie = await _tvSerieRepository.GetByIdAsync(id);

            SaveTvSerieViewModel vm = new();
            {
                vm.Id = tvserie.Id;
                vm.Name = tvserie.Name;
                vm.Link = tvserie.Link;
                vm.ImgLink = tvserie.ImgLink;
                vm.ProducerId = tvserie.ProducerId;
                vm.GenderId = tvserie.GenderId;
            }

            return vm;
        }

        public async Task<List<TvSerieViewModel>> GetAllViewModel()
        {
            var tvserieList = await _tvSerieRepository.GetAllAsync();
            return tvserieList.Select(tvserie => new TvSerieViewModel
            {
                Id = tvserie.Id,
                Name = tvserie.Name,
                Link = tvserie.Link,
                ImgLink = tvserie.ImgLink,
                ProducerId = tvserie.ProducerId,
                GenderId = tvserie.GenderId
            }).ToList();
        }
    }
}
