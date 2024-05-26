using Fiu.Core.Models;
using Fiu.Core.RepositoryAbstracts;
using Fiu.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiu.Data.RepositoryConcretes
{
    public class FurnitureRepository : GenericRepository<Furniture>, IFurnitureRepository
    {
        public FurnitureRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
