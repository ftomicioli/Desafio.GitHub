using Desafio.GitHub.Domain.Entities;
using Desafio.GitHub.Domain.Interfaces;
using Desafio.GitHub.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.GitHub.Application
{
    public class RepositorioApplication
    {
        private readonly IRepositorioService _repositorioService;

        public RepositorioApplication(IRepositorioService repositorioService)
        {
            _repositorioService = repositorioService;
        }

        public ListarRepositoriosRetornoDto ListarRepositorios()
        {
            var resultVo = _repositorioService.ListarRepositorios();

            return new ListarRepositoriosRetornoDto
            {
                Erro = resultVo.Erro,
                MensagemErro = resultVo.MensagemErro,
                repositorios = resultVo.repositorios.Select(a => (RepositorioRetornoDto)a).ToList()
            };
        }

        public ListarRepositoriosFavoritadosRetornoDto ListarRepositoriosFavoritados()
        {
            var result = _repositorioService.ListarRepositoriosFavoritados();

            return new ListarRepositoriosFavoritadosRetornoDto
            {
                Erro = result.Erro,
                MensagemErro = result.MensagemErro,
                RepositoriosFavoritados = result.RepositoriosFavoritados.Select(a => (RepositoriosFavoritadosRetornoDto)a).ToList()
            };
        }

        public FavoritarRepositorioRetornoDto FavoritarRepositorio(long id)
        {
            var resultVo = _repositorioService.FavoritarRepositorio(id);

            return new FavoritarRepositorioRetornoDto()
            {
                Erro = resultVo.Erro,
                MensagemErro = resultVo.MensagemErro,
                RepositorioFavoritadoComSucesso = resultVo.RepositorioFavoritadoComSucesso
            };
        }

        public DesfavoritarRepositorioRetornoDto DesfavoritarRepositorio(long id)
        {
            var resultVo = _repositorioService.DesFavoritarRepositorio(id);

            return new DesfavoritarRepositorioRetornoDto()
            {
                Erro = resultVo.Erro,
                MensagemErro = resultVo.MensagemErro,
                RepositorioDesfavoritadoComSucesso = resultVo.RepositorioDesfavoritadoComSucesso
            };
        }
    }
}
