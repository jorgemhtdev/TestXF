namespace TestXF.Test.Mocks.Repositories
{
    using Moq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestXF.Interfaces;
    using TestXF.Models;

    public class MockFilmRepository : Mock<IApiService>
    {
        public MockFilmRepository MockGetAllFilm(List<Film> results)
        {
            Setup(film => film.GetAllFilm()).Returns(Task.FromResult(results));

            return this;
        }
    }
}
