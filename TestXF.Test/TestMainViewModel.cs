namespace TestXF.Test
{
    using FluentAssertions;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TestXF.Models;
    using TestXF.Test.Mocks.Repositories;
    using TestXF.ViewModels;
    using Xunit;

    public class TestMainViewModel : Tests
    {
        public MainViewModel mainViewModel;

        public TestMainViewModel()
        {
            mainViewModel = new MainViewModel(DependencyService);
        }

        [Fact]
        public void Test_Login_Success()
        {
            mainViewModel.UserName = "jorgemht";
            mainViewModel.Password = "1q2w3e4r5t";

            mainViewModel.Login();

            mainViewModel.IsAuthenticated.Should().BeTrue();
        }

        [Fact]
        public void Test_GetAllFilm_True()
        {
            ConnMock.Setup(m => m.Connected).Returns(true);

            mainViewModel.LoadFilm();

            mainViewModel.Films.Should().NotBeNull();
        }

        [Fact] // Fallo a aposta
        public void Test_GetAllFilm_Fail()
        {
            ConnMock.Setup(m => m.Connected).Returns(false);

            mainViewModel.LoadFilm();

            mainViewModel.Films.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Success_Case()
        {
            //Arrange
            var mockFilm = GetMockFilm();

            //Act
            var mockFilmRepo = new MockFilmRepository().MockGetAllFilm(mockFilm);
            var films = await mockFilmRepo.Object.GetAllFilm();

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
