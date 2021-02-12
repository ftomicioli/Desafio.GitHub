using Desafio.GitHub.Domain.ValueObjects.Facades;
using System.Collections.Generic;

namespace Desafio.GitHub.Domain.Facades.Interfaces
{
    public interface IRepositorioFacade
    {
        ListarRepositoriosRetornoVo ListarRepositorios();
    }
}
