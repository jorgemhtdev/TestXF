namespace TestXF.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Refit;
    using TestXF.Interfaces;
    using TestXF.Models;

    public class ApiService : IApiService
    {
        private string baseUrl = "https://my-json-server.typicode.com/jorgemht/demo/";

        private readonly IFilmService filmService;

        public ApiService()
        {
            filmService = RestService.For<IFilmService>(baseUrl);
        }

        public async Task<List<Film>> GetAllFilm() => await filmService.GetAll();
    }
}
