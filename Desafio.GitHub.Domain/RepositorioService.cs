using Desafio.GitHub.Domain.Entities;
using Desafio.GitHub.Domain.Facades.Interfaces;
using Desafio.GitHub.Domain.Interfaces;
using Desafio.GitHub.Domain.Repositories.Interface;
using Desafio.GitHub.Domain.ValueObjects;
using Desafio.GitHub.Domain.ValueObjects.Facades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.GitHub.Domain
{
    public class RepositorioService : IRepositorioService
    {
        private readonly IRepositorioFacade _repositorioFacade;
        private readonly IRepositorioFavoritadoRepository _repositorioFavoritadoRepository;

        public RepositorioService(IRepositorioFacade repositorioFacade, IRepositorioFavoritadoRepository repositorioFavoritadoRepository)
        {
            _repositorioFacade = repositorioFacade;
            _repositorioFavoritadoRepository = repositorioFavoritadoRepository;
        }

        public ListarRepositoriosRetornoVo ListarRepositorios()
        {
            try
            {
                return _repositorioFacade.ListarRepositorios();
            }
            catch (Exception e)
            {
                return new ListarRepositoriosRetornoVo(erro: true, mensagemErro: e.Message);
            }
        }

        public ListarRepositorioFavoritadosRetornoVo ListarRepositoriosFavoritados()
        {
            try
            {
                var result = _repositorioFavoritadoRepository.ListarRepositoriosFavoritados();

                return new ListarRepositorioFavoritadosRetornoVo
                {
                    RepositoriosFavoritados = result
                };
            }
            catch (Exception e)
            {
                return new ListarRepositorioFavoritadosRetornoVo(erro: true, mensagemErro: e.Message);
            }
        }

        public FavoritarRepositorioRetornoVo FavoritarRepositorio(long id)
        {
            if (id == 0)
            {
                return new FavoritarRepositorioRetornoVo(erro: true, mensagemErro: "Favor informar repositório");
            }

            var resultado = _repositorioFacade.ListarRepositorios();

            var repositorioExiste = resultado.repositorios.Where(p => p.Id == id).FirstOrDefault();

            if (repositorioExiste == null)
            {
                return new FavoritarRepositorioRetornoVo(erro: true, mensagemErro: "Repositorio não existe");
            }

            var resultadoListarRepositoriosFavoritados = ListarRepositoriosFavoritados();

            if (resultadoListarRepositoriosFavoritados.Erro)
            {
                return new FavoritarRepositorioRetornoVo(erro: true, mensagemErro: resultadoListarRepositoriosFavoritados.MensagemErro);
            }

            var repositorioJaFoiFavoritados = ListarRepositoriosFavoritados().RepositoriosFavoritados.Where(p => p.Id == id).Any();

            if (repositorioJaFoiFavoritados == true)
            {
                return new FavoritarRepositorioRetornoVo(erro: true, mensagemErro: "Repositorio ja foi favoritado");
            }

            _repositorioFavoritadoRepository.FavoritarRepositorio(new RepositorioFavoritado() { Id = repositorioExiste.Id, Name = repositorioExiste.Name });

            return new FavoritarRepositorioRetornoVo(repositorioFavoritadoComSucesso: true);
        }

        public DesfavoritarRepositorioRetornoVo DesFavoritarRepositorio(long id)
        {
            if (id == 0)
            {
                return new DesfavoritarRepositorioRetornoVo(erro: true, mensagemErro: "Favor informar repositório");
            }

            var resultadoListarRepositoriosFavoritados = ListarRepositoriosFavoritados();

            if (resultadoListarRepositoriosFavoritados.Erro)
            {
                return new DesfavoritarRepositorioRetornoVo(erro: true, mensagemErro: resultadoListarRepositoriosFavoritados.MensagemErro);
            }

            var repositorioJaFoiFavoritados = resultadoListarRepositoriosFavoritados.RepositoriosFavoritados.Where(p => p.Id == id).Any();

            if (repositorioJaFoiFavoritados == false)
            {
                return new DesfavoritarRepositorioRetornoVo(erro: true, mensagemErro: "Repositorio não foi favoritado");
            }

            var desfavoritado = _repositorioFavoritadoRepository.DesFavoritarRepositorio(id);

            return new DesfavoritarRepositorioRetornoVo(repositorioDesfavoritadoComSucesso: desfavoritado);
        }
    }
}
