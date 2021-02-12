using Desafio.GitHub.CrossCutting.Http;
using Desafio.GitHub.CrossCutting.Settings;
using Desafio.GitHub.Domain.Integration;
using Desafio.GitHub.Domain.ValueObjects.Facades;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Desafio.GitHub.Integration.Http
{
    public class RepositorioIntegration : IRepositorioIntegration
    {
        private readonly ApiSettings _apiSettings;

        public RepositorioIntegration(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
        }

        public List<ListarRepositoriosFacadeRetornoVo> ListarRepositorios()
        {
            List<ListarRepositoriosFacadeRetornoVo> result = HttpHelper<List<ListarRepositoriosFacadeRetornoVo>>.HttpRequest($"{_apiSettings.UrlRepositorioGitHub}/repos", method: CustomHttpVerbs.Get);
            return result;
        }
    }
}
