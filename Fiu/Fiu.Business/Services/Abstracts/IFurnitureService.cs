using Fiu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiu.Business.Services.Abstracts
{
    public interface IFurnitureService 
    {
        Task AddFurnitureAsync(Furniture furniture);
        void DeleteFurniture(int id);
        void UpdateFurniture(int id, Furniture newFurniture);
        Furniture GetFurniture(Func<Furniture, bool>? func = null);
        List<Furniture> GetAllFurnitures(Func<Furniture, bool>? func = null);

    }
}
