namespace TestXF.Interfaces
{
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFilmService
    {
        [Get("/film")]
        Task<List<Models.Film>> GetAll();
    }
}
