using Desafio.GitHub.Domain.ValueObjects.Facades;
using System.Collections.Generic;

namespace Desafio.GitHub.Domain.Integration
{
    public interface IRepositorioIntegration
    {
        List<ListarRepositoriosFacadeRetornoVo> ListarRepositorios();
    }
}
