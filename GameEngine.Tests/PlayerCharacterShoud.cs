using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShoud : IDisposable
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly PlayerCharacter _sut;

        public PlayerCharacterShoud(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _outputHelper.WriteLine("Creating new player test");
            _sut = new PlayerCharacter();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            _sut.FirstName = "Robert";
            _sut.LastName = "K";

            Assert.Equal("Robert K", _sut.FullName);
        }

        [Fact]
        public void CalculateFullNameEndingWithfFirstName()
        {
            _sut.FirstName = "Robert";
            _sut.LastName = "K";

            Assert.EndsWith("K", _sut.FullName);
        }

        [Fact]
        public void CalculateFullNameIgnoreCase()
        {
            _sut.FirstName = "ROBERT";
            _sut.LastName = "K";

            Assert.Equal("Robert K", _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullNameRegex()
        {
            _sut.FirstName = "Robert";
            _sut.LastName = "Kr";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }

        [Fact]
        public void CalculateFullNameStartingWithfFirstName()
        {
            _sut.FirstName = "Robert";
            _sut.LastName = "K";

            Assert.StartsWith("Robert", _sut.FullName);
        }

        [Fact]
        public void CalculateFullNameSubstring()
        {
            _sut.FirstName = "Robert";
            _sut.LastName = "K";

            Assert.Contains("rt K", _sut.FullName);
        }

        public void Dispose()
        {
            // _sut.Dispose();
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneSword()
        {
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveNoEmptyWeapons()
        {
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void IncrasetHealthAfterSleep()
        {
            _sut.Sleep();

            Assert.True(_sut.Health >= 101 && _sut.Health <= 200);
            Assert.InRange(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveAStaff()
        {
            Assert.DoesNotContain("Staff", _sut.Weapons);
        }

        [Fact]
        public void NotHaveNickByDefault()
        {
            Assert.Null(_sut.Nickname);
        }

        [Fact]
        public void RaisePropertyChangeEvent()
        {
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(19));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(handler => _sut.PlayerSlept += handler, handler => _sut.PlayerSlept -= handler, () => _sut.Sleep());
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealthNotEqual()
        {
            Assert.NotEqual(0, _sut.Health);
        }
    }
}