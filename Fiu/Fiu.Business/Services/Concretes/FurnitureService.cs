using Fiu.Business.Exceptions;
using Fiu.Business.Extensions;
using Fiu.Business.Services.Abstracts;
using Fiu.Core.Models;
using Fiu.Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiu.Business.Services.Concretes
{
    public class FurnitureService : IFurnitureService
    {
        private readonly IFurnitureRepository _furnitureRepository;
        private readonly IWebHostEnvironment _env;
        public FurnitureService(IFurnitureRepository furnitureRepository, IWebHostEnvironment env)
        {
            _furnitureRepository = furnitureRepository;
            _env = env;
        }

        public async Task AddFurnitureAsync(Furniture furniture)
        {
            if (furniture.ImageFile == null)
                throw new ImageFileException("Image olmalidir!");

            furniture.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\furnitures", furniture.ImageFile);

            await _furnitureRepository.AddAsync(furniture);
            await _furnitureRepository.CommitAsync();
        }

        public void DeleteFurniture(int id)
        {
            var existFurniture = _furnitureRepository.Get(x=> x.Id == id);

            if (existFurniture == null)
                throw new EntityNotFoundException("Furniture movcud deyil!"); 

            Helper.DeleteFile(_env.WebRootPath, @"uploads\furnitures", existFurniture.ImageUrl);    

            _furnitureRepository.Delete(existFurniture);
            _furnitureRepository.Commit();
        }

        public List<Furniture> GetAllFurnitures(Func<Furniture, bool>? func = null)
        {
            return _furnitureRepository.GetAll(func);
        }

        public Furniture GetFurniture(Func<Furniture, bool>? func = null)
        {
            return _furnitureRepository.Get(func);
        }

        public void UpdateFurniture(int id, Furniture newFurniture)
        {
            var oldFurniture = _furnitureRepository.Get(x => x.Id == id);

            if (oldFurniture == null)
                throw new EntityNotFoundException("Furniture movcud deyil!");

            if(newFurniture.ImageFile != null)
            {
                if (newFurniture.ImageFile.ContentType != "image/png")
                    throw new FileContentTypeException("File formati png olmalidir!");

                Helper.DeleteFile(_env.WebRootPath, @"uploads\furnitures", oldFurniture.ImageUrl);

                oldFurniture.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\furnitures", newFurniture.ImageFile);
            }

            oldFurniture.Title = newFurniture.Title;
            oldFurniture.Price = newFurniture.Price;
            oldFurniture.RedirectUrl = newFurniture.RedirectUrl;

            _furnitureRepository.Commit();
        }
    }
}
