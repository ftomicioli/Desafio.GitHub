using Desafio.GitHub.Domain.Facades.Interfaces;
using Desafio.GitHub.Domain.Integration;
using Desafio.GitHub.Domain.ValueObjects;
using Desafio.GitHub.Domain.ValueObjects.Facades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.GitHub.Domain.Facades
{
    public class RepositorioFacade : IRepositorioFacade
    {
        private readonly IRepositorioIntegration _repositorioIntegration;

        public RepositorioFacade(IRepositorioIntegration repositorioIntegration)
        {
            _repositorioIntegration = repositorioIntegration;
        }

        public ListarRepositoriosRetornoVo ListarRepositorios()
        {
            try
            {
                var resultVo = _repositorioIntegration.ListarRepositorios();

                return new ListarRepositoriosRetornoVo
                {
                    repositorios = resultVo.Select(a => (RepositoriosRetornoVo)a).ToList()
                };
            }
            catch (Exception e)
            {
                return new ListarRepositoriosRetornoVo(erro: true, mensagemErro: e.Message);
            }
        }
    }
}
