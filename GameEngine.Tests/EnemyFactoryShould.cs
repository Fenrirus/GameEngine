using System;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateBossEnemy()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie King", true);
            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_AssertAsignableTypes()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie King", true);
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedByExample()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie King", true);
            var boss = Assert.IsType<BossEnemy>(enemy);
            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact(Skip = "dont run this")]
        public void CreateNormalEnemyByDefault()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie");
            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateSepareteInstance()
        {
            var sut = new EnemyFactory();
            var enemy = sut.Create("Zombie");
            var enemy2 = sut.Create("Zombie");
            Assert.NotSame(enemy, enemy2);
        }

        [Fact]
        public void NotAllowNull()
        {
            var sut = new EnemyFactory();

            Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }

        [Fact]
        public void OnlyQueenORKingBoss()
        {
            var sut = new EnemyFactory();
            Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));
        }
    }
}