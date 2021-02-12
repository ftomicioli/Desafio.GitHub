using AutoFixture;
using Desafio.GitHub.Domain;
using Desafio.GitHub.Domain.Entities;
using Desafio.GitHub.Domain.Facades.Interfaces;
using Desafio.GitHub.Domain.Infrastructure.Interfaces;
using Desafio.GitHub.Domain.Integration;
using Desafio.GitHub.Domain.Interfaces;
using Desafio.GitHub.Domain.Repositories.Interface;
using Desafio.GitHub.Domain.ValueObjects;
using Desafio.GitHub.Domain.ValueObjects.Facades;
using Desafio.GitHub.Tests.Attributes;
using Desafio.GitHub.Tests.Helper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Desafio.GitHub.Tests.Services
{
    public class RepositorioServiceTest
    {
        private readonly IFixture _fixture;
        private readonly ITestOutputHelper _logTest;

        public RepositorioServiceTest(ITestOutputHelper logTest)
        {
            _fixture = AutoMoqFixtureFactory.CreateFixture();
            _logTest = logTest;
        }

        [Fact(DisplayName = "Favoritar repositório com retorno inválido quando não informa o id do repositório")]
        [Trait("RepositorioService", "FavoritarRepositorio")]
        public void FavoritarRepositorio_QuandoNaoInformaIdDoRepositorio_Invalido()
        {
            #region Arrange
            var repositorioService = _fixture.Create<RepositorioService>();
            #endregion

            #region Act
            var retornoService = repositorioService.FavoritarRepositorio(0);
            #endregion

            #region Assert
            retornoService.Erro.ShouldBe(true);
            retornoService.MensagemErro.ShouldBe("Favor informar repositório");
            retornoService.RepositorioFavoritadoComSucesso.ShouldBe(false);
            #endregion
        }

        [Theory(DisplayName = "Favoritar repositório com retorno inválido quando repositório informado não existe")]
        [Trait("RepositorioService", "FavoritarRepositorio")]
        [AutoMoqData]
        public void FavoritarRepositorio_QuandoRepositorioInformadoNaoExiste_Invalido(long id)
        {
            #region Arrange
            var repositorioIntegration = _fixture.Freeze<Mock<IRepositorioIntegration>>();
            var repositorioFacade = _fixture.Freeze<Mock<IRepositorioFacade>>();

            ListarRepositoriosRetornoVo listarRepositoriosRetornoVo = new ListarRepositoriosRetornoVo();
            listarRepositoriosRetornoVo.repositorios = new List<RepositoriosRetornoVo>();

            repositorioFacade.Setup(p => p.ListarRepositorios()).Returns(listarRepositoriosRetornoVo);

            #endregion

            #region Act
            var repositorioService = _fixture.Create<RepositorioService>();
            var retornoService = repositorioService.FavoritarRepositorio(id);
            #endregion

            #region Assert
            retornoService.Erro.ShouldBe(true);
            retornoService.MensagemErro.ShouldBe("Repositorio não existe");
            retornoService.RepositorioFavoritadoComSucesso.ShouldBe(false);
            #endregion
        }

        [Theory(DisplayName = "Favoritar repositório com retorno inválido quando ocorre erro inesperado ao listar os repositórios favoritados")]
        [Trait("RepositorioService", "FavoritarRepositorio")]
        [AutoMoqData]
        public void FavoritarRepositorio_QuandoOcorreErroInesperadoAoListarRepositoriosFavoritados_Invalido(long id)
        {
            #region Arrange
            var repositorioIntegration = _fixture.Freeze<Mock<IRepositorioIntegration>>();
            var repositorioFacade = _fixture.Freeze<Mock<IRepositorioFacade>>();

            var desafioUnitOfWork = _fixture.Freeze<Mock<IDesafioUnitOfWork>>();
            var repositorioFavoritadoRepository = _fixture.Freeze<Mock<IRepositorioFavoritadoRepository>>();

            ListarRepositoriosRetornoVo listarRepositoriosRetornoVo = new ListarRepositoriosRetornoVo()
            {
                repositorios = new List<RepositoriosRetornoVo>() { new RepositoriosRetornoVo() { Id = id } }
            };

            repositorioFacade.Setup(p => p.ListarRepositorios())
                .Returns(listarRepositoriosRetornoVo);

            repositorioFavoritadoRepository.Setup(p => p.ListarRepositoriosFavoritados())
                .Throws(new Exception("Erro inesperado"));
            #endregion

            #region Act
            var repositorioService = _fixture.Create<RepositorioService>();
            var retornoService = repositorioService.FavoritarRepositorio(id);
            #endregion

            #region Assert
            retornoService.Erro.ShouldBe(true);
            retornoService.MensagemErro.ShouldBe("Erro inesperado");
            retornoService.RepositorioFavoritadoComSucesso.ShouldBe(false);
            #endregion
        }

        [Theory(DisplayName = "Favoritar repositório com retorno inválido quando tenta favoritar repositório já favoritado")]
        [Trait("RepositorioService", "FavoritarRepositorio")]
        [AutoMoqData]
        public void FavoritarRepositorio_QuandoTentaFavoritarRepositorioJaFavoritado_Invalido(long id)
        {
            #region Arrange
            var repositorioIntegration = _fixture.Freeze<Mock<IRepositorioIntegration>>();
            var repositorioFacade = _fixture.Freeze<Mock<IRepositorioFacade>>();

            var desafioUnitOfWork = _fixture.Freeze<Mock<IDesafioUnitOfWork>>();
            var repositorioFavoritadoRepository = _fixture.Freeze<Mock<IRepositorioFavoritadoRepository>>();

            ListarRepositoriosRetornoVo listarRepositoriosRetornoVo = new ListarRepositoriosRetornoVo()
            {
                repositorios = new List<RepositoriosRetornoVo>() { new RepositoriosRetornoVo() { Id = id } }
            };

            List<RepositorioFavoritado> repositorioFavoritados = new List<RepositorioFavoritado>()
            {
                 new RepositorioFavoritado() { Id = id}
            };

            repositorioFacade.Setup(p => p.ListarRepositorios())
                .Returns(listarRepositoriosRetornoVo);

            repositorioFavoritadoRepository.Setup(p => p.ListarRepositoriosFavoritados()).Returns(repositorioFavoritados);
            #endregion

            #region Act
            var repositorioService = _fixture.Create<RepositorioService>();
            var retornoService = repositorioService.FavoritarRepositorio(id);
            #endregion

            #region Assert
            retornoService.Erro.ShouldBe(true);
            retornoService.MensagemErro.ShouldBe("Repositorio ja foi favoritado");
            retornoService.RepositorioFavoritadoComSucesso.ShouldBe(false);
            #endregion
        }

        [Theory(DisplayName = "Favoritar repositório com retorno válido quando favoritar ocorre com sucesso")]
        [Trait("RepositorioService", "FavoritarRepositorio")]
        [AutoMoqData]
        public void FavoritarRepositorio_QuandoFavoritarOcorreComSucesso_Valido(long id)
        {
            #region Arrange
            var repositorioIntegration = _fixture.Freeze<Mock<IRepositorioIntegration>>();
            var repositorioFacade = _fixture.Freeze<Mock<IRepositorioFacade>>();

            var desafioUnitOfWork = _fixture.Freeze<Mock<IDesafioUnitOfWork>>();
            var repositorioFavoritadoRepository = _fixture.Freeze<Mock<IRepositorioFavoritadoRepository>>();

            ListarRepositoriosRetornoVo listarRepositoriosRetornoVo = new ListarRepositoriosRetornoVo()
            {
                repositorios = new List<RepositoriosRetornoVo>() { new RepositoriosRetornoVo() { Id = id } }
            };

            repositorioFacade.Setup(p => p.ListarRepositorios())
                .Returns(listarRepositoriosRetornoVo);
            #endregion

            #region Act
            var repositorioService = _fixture.Create<RepositorioService>();
            var retornoService = repositorioService.FavoritarRepositorio(id);
            #endregion

            #region Assert
            retornoService.Erro.ShouldBe(false);
            retornoService.MensagemErro.ShouldBe(null);
            retornoService.RepositorioFavoritadoComSucesso.ShouldBe(true);
            #endregion
        }
    }
}
