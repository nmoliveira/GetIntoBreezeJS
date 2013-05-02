using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GetIntoBreezeJS.Models
{
    public class GetIntoBreezeInitializer : DropCreateDatabaseAlways<GetIntoBreezeContext>
    {
        protected override void Seed(GetIntoBreezeContext context)
        {
            var cities = new[]
                {
                    new City{CountryName="Portugal",CityName="Lisbon"},
                    new City{CountryName="Portugal",CityName="Porto"},
                    new City{CountryName="Portugal",CityName="Coimbra"},
                    new City{CountryName="Portugal",CityName="Aveiro"},
                    new City{CountryName="Spain",CityName="Madrid"},
                    new City{CountryName="Spain",CityName="Barcelona"},
                    new City{CountryName="Spain",CityName="Valencia"},
                    new City{CountryName="France",CityName="Paris"},
                    new City{CountryName="France",CityName="Nice"},
                    new City{CountryName="Belgium",CityName="Brussels"},
                    new City{CountryName="Austria",CityName="Viena"},
                    new City{CountryName="Bulgaria",CityName="Sofia"},
                    new City{CountryName="Greece",CityName="Athens"},
                    new City{CountryName="Germany",CityName="Berlin"},
                    new City{CountryName="United Kingdom",CityName="London"},
                    new City{CountryName="United Kingdom",CityName="Manchester"},
                    new City{CountryName="United Kingdom",CityName="Southampton"},
                    new City{CountryName="Netherlands",CityName="Amsterdam"},
                    new City{CountryName="Angola",CityName="Luanda"},
                    new City{CountryName="Mozambique",CityName="Maputo"},
                    new City{CountryName="Brazil",CityName="Brasilia"},
                    new City{CountryName="Brazil",CityName="Rio de Janeiro"},
                    new City{CountryName="Argentina",CityName="Buenos Aires"},
                    new City{CountryName="United States",CityName="Washington, D.C."},
                    new City{CountryName="United States",CityName="New York"},
                    new City{CountryName="United States",CityName="Seatle"},
                    new City{CountryName="United States",CityName="San Francisco"},
                    new City{CountryName="China",CityName="Beijing"},
                    new City{CountryName="Japan",CityName="Tokio"},
                };

            Array.ForEach(cities, c => context.Cities.Add(c));

            context.SaveChanges(); // Save cities
        }
    }
}