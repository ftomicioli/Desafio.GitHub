using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.GitHub.Application;
using Desafio.GitHub.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.GitHub.WebApi2.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RepositoriosController : Controller
    {
        private readonly RepositorioApplication _repositorioApplication;

        public RepositoriosController(RepositorioApplication repositorioApplication)
        {
            _repositorioApplication = repositorioApplication;
        }

        [HttpGet]
        [Route("ListarRepositorios")]
        public ListarRepositoriosRetornoDto ListarRepositorios()
        {
            return _repositorioApplication.ListarRepositorios();
        }

        [HttpGet]
        [Route("ListarRepositoriosFavoritados")]
        public ListarRepositoriosFavoritadosRetornoDto ListarRepositoriosFavoritados()
        {
            return _repositorioApplication.ListarRepositoriosFavoritados();
        }

        [HttpPost]
        [Route("FavoritarRepositorio")]
        public FavoritarRepositorioRetornoDto FavoritarRepositorio(long id)
        {
            return _repositorioApplication.FavoritarRepositorio(id);
        }

        [HttpPost]
        [Route("DesfavoritarRepositorio")]
        public DesfavoritarRepositorioRetornoDto DesfavoritarRepositorio(long id)
        {
            return _repositorioApplication.DesfavoritarRepositorio(id);
        }
    }
}
