using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class NonePlayerCharacterShould
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly PlayerCharacter _sut;

        public NonePlayerCharacterShould(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _outputHelper.WriteLine("Creating new player test");
            _sut = new PlayerCharacter();
        }

        [Theory]
        //[MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        //[MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        [HealthDmgDataAttr]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, _sut.Health);
        }
    }
}