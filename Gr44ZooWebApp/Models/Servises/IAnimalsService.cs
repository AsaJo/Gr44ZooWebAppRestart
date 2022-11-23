using Gr44ZooWebApp.Models.ViewModels;

namespace Gr44ZooWebApp.Models.Servises
{
    public interface IAnimalsService
    {
        Animal Create(CreateAnimalViewModel createAnimal);
        List<Animal> GetAll();
        List<Animal> FindBySpecies(string species);
        Animal FindById(int id);
        void Edit(int id, CreateAnimalViewModel editAnimal);
        void Remove(int id);
        Animal LastAdded();
    }
}
