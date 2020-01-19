namespace TestXF.Test
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestXF.Models;
    using TestXF.Test.Mocks.Repositories;
    using Xunit;

    public class TestMainViewModel : Tests
    {
        [Fact]
        public async Task Test_Success_Case()
        {
            //Arrange
            var mockFilm = GetMockFilm();

            //Act
            var mockPlayerRepo = new MockFilmRepository().MockGetAllFilm(mockFilm);
            var films = await mockPlayerRepo.Object.GetAllFilm();

            //Assert
            films.Should().NotBeNull();
        }

        private List<Film> GetMockFilm()
        {
            return new List<Film>()
            {
                new Film()
                { 
                    FilmId = 1,
                    Title = "El resplandor",
                    OriginalTitle = "The Shining",
                    Imdb = "8.2",
                    Year = "1987",
                    Duration = "1980"
                 },
                new Film()
                {
                    FilmId = 2,
                    Title = "La chaqueta metálica",
                    OriginalTitle = "Full Metal Jacket",
                    Imdb = "8.2",
                    Year = "1987",
                    Duration = "120"
                 },
                new Film()
                {
                    FilmId = 3,
                    Title = "La naranja mecánica",
                    OriginalTitle = "A Clockwork Orange",
                    Imdb = "8.2",
                    Year = "1971",
                    Duration = "137"
                 },
            };
        }
    }
}
