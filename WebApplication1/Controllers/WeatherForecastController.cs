using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly NewInEFContext _newInEFContext;

        public WeatherForecastController(NewInEFContext newInEFContext)
        {
            _newInEFContext = newInEFContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<int> Get()
        {
            //using (var context = new NewInEFContext())
            //{
            //    //SetupAndPopulate(context);

            //    //var aaa =  context.Pets.Where(p => p.Name.Contains("1")).ToList();

            //}

            var aaa1 = _newInEFContext.Pets.Where(p => p.Name.Contains("1")).ToList();

            return Enumerable.Range(1, 5);
        }
        static void SetupAndPopulate(NewInEFContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Persons.AddRange(Enumerable.Range(1, 1_000).Select(i =>
            {
                return new Person
                {
                    FirstName = $"{nameof(Person.FirstName)}-{i}",
                    LastName = $"{nameof(Person.LastName)}-{i}",
                    Address = new Address
                    {
                        Street = $"{nameof(Address.Street)}-{i}",
                    },
                    Pets = Enumerable.Range(1, 3).Select(i2 =>
                    {
                        return new Pet
                        {
                            Breed = $"{nameof(Pet.Breed)}-{i}-{i2}",
                            Name = $"{nameof(Pet.Name)}-{i}-{i2}",
                        };
                    }).ToList()
                };
            }));

            var aaCount =  context.SaveChanges();
        }
    }
}