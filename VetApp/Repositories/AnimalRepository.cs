using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Models;
using VetApp.Data;
using System.Collections;

namespace VetApp.Repositories
{
    internal class AnimalRepository
    {
        public IEnumerable<Animal> GetAll()
        {
            AnimalDataSource animalDataSource = new AnimalDataSource();
            return animalDataSource.GetAll();
        }
    }
}
