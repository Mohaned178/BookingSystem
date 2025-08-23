using EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Services
{
    public interface IResourceService
    {
        void AddResource(Resource resource);
        Resource GetResourceById(int id);
        IEnumerable<Resource> GetAllResources();
        void UpdateResource(Resource resource);
        void DeleteResource(int id);

    }
}
