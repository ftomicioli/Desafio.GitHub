using AutoFixture.Xunit2;
using Desafio.GitHub.Tests.Helper;

namespace Desafio.GitHub.Tests.Attributes
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(() => AutoMoqFixtureFactory.CreateFixture()) { }
    }
}
