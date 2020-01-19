namespace TestXF.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IApiService
    {
        Task<List<Models.Film>> GetAllFilm();
    }
}
