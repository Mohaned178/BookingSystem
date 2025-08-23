using EfCore.Data;
using EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Services
{
    public class ResourceService : IResourceService
    {
        private readonly ApplicationDbContext _context;
        public ResourceService()
        {
            _context = new ApplicationDbContext();
        }
        public void AddResource(Resource resource)
        {
            _context.Resources.Add(resource);
            _context.SaveChanges();
        }

        public void DeleteResource(int id)
        {
            var resource = _context.Resources.Find(id);
            if (resource != null)
            {
                _context.Resources.Remove(resource);
                _context.SaveChanges();
            }
            }

        public IEnumerable<Resource> GetAllResources()
        {
            return _context.Resources.ToList();
        }

        public Resource GetResourceById(int id)
        {
            return _context.Resources.FirstOrDefault(r => r.Id == id);
        }

        public void UpdateResource(Resource resource)
        {
            _context.Resources.Update(resource);
            _context.SaveChanges();
        }
    }
}
