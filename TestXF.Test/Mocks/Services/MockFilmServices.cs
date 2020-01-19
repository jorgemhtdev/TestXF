namespace TestXF.Test.Mocks.Services
{
    using Moq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestXF.Interfaces;
    using TestXF.Models;

    public class MockFilmServices : Mock<IApiService>
    {
        public MockFilmServices GetAll(List<Film> results)
        {
            Setup(x => x.GetAllFilm()).Returns(Task.FromResult(results));

            return this;
        }
    }
}