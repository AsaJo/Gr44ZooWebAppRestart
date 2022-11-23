namespace Gr44ZooWebApp.Models.Repos
{
    public class InMemoryRepo : IAnimalsRepo
    {
        static int idCounter=0;
        static List<Animal> animalsList = new List<Animal>();
        public Animal Create(Animal animal)
        {
            animal.Id = ++idCounter;
            animalsList.Add(animal);
            return animal;
        }

        public List<Animal> GetAll()
        {
            return animalsList;
        }

        public List<Animal> GetBySpecies(string species)
        {
            List<Animal> animalSpecies = new List<Animal>();
            foreach (Animal aAnimal in animalsList)
            {
                if (aAnimal.Species == species)
                {
                    animalSpecies.Add(aAnimal);
                }
            }
            return animalSpecies;
        }
        public Animal GetById(int id)
        {
            Animal? animal = null;
            foreach (Animal? aAnimal in animalsList)
            {
                if (aAnimal.Id == id)
                {
                    animal = aAnimal;
                    break;
                }
            }
            return animal;
        }

        public void Update(Animal animal)
        {
            Animal orginalAnimal = GetById(animal.Id);
            if (orginalAnimal != null)
            {
                orginalAnimal.AnimalName = animal.AnimalName;
                orginalAnimal.Species = animal.Species;
                orginalAnimal.CalledByName = animal.CalledByName;
                orginalAnimal.Quantity = animal.Quantity;
            }
        }

        public void Delete(Animal animal)
        {
            if (animal!= null)
            {
                animalsList.Remove(animal);

            }
        }
    }
}
