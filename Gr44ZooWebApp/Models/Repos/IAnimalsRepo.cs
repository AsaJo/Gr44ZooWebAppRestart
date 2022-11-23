namespace Gr44ZooWebApp.Models.Repos
{
    public interface IAnimalsRepo
    {
        //Crud
        
        // C

        Animal Create(Animal animal);
        // R
        List<Animal> GetAll();
        List<Animal> GetBySpecies(string species);
        Animal GetById(int id);

        // U
        void Update(Animal animal);

        // D
        void Delete(Animal animal);
      
    }
}
