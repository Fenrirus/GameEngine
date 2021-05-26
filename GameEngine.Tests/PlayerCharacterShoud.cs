using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShoud
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Robert";
            sut.LastName = "K";

            Assert.Equal("Robert K", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameEndingWithfFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Robert";
            sut.LastName = "K";

            Assert.EndsWith("K", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameIgnoreCase()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "ROBERT";
            sut.LastName = "K";

            Assert.Equal("Robert K", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullNameRegex()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Robert";
            sut.LastName = "Kr";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameStartingWithfFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Robert";
            sut.LastName = "K";

            Assert.StartsWith("Robert", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameSubstring()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Robert";
            sut.LastName = "K";

            Assert.Contains("rt K", sut.FullName);
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveALongBow()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneSword()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveNoEmptyWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void IncrasetHealthAfterSleep()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep();

            Assert.True(sut.Health >= 101 && sut.Health <= 200);
            Assert.InRange(sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveAStaff()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.DoesNotContain("Staff", sut.Weapons);
        }

        [Fact]
        public void NotHaveNickByDefault()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealthNotEqual()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0, sut.Health);
        }
    }
}