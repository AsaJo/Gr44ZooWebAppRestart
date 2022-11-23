using Gr44ZooWebApp.Data;
using System.Linq;


namespace Gr44ZooWebApp.Models.Repos
{
    public class DatabaseAnimaslRepo : IAnimalsRepo
    {
        readonly ZooDbContext _zooDbContext;
        public DatabaseAnimaslRepo(ZooDbContext zooDbContext) 
        {
            _zooDbContext = zooDbContext;

        }
        public Animal Create(Animal animal)
        {
            
                _zooDbContext.Add(animal);
                _zooDbContext.SaveChanges();
                 return animal;
        }

        public List<Animal> GetAll()
        {
            return _zooDbContext.Animals.ToList();
        }

        public Animal GetById(int id)
        {
            return _zooDbContext.Animals.SingleOrDefault(animal => animal.Id == id);
        
        }

        public List<Animal> GetBySpecies(string species)
        {
            return _zooDbContext.Animals.Where(animal=> animal.Species.Contains(species)).ToList();
        }

        public void Update(Animal animal)
        {
            _zooDbContext.Animals.Update(animal);
            _zooDbContext.SaveChanges();
        }
        public void Delete(Animal animal)
        {
            _zooDbContext.Animals.Remove(animal);
            _zooDbContext.SaveChanges();
        }
    }
}
