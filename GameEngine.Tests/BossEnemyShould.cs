using Xunit;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        [Fact]
        public void HaveCorrectPower()
        {
            var sut = new BossEnemy();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
    }
}