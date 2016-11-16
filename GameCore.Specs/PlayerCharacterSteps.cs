using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterSteps :  TechTalk.SpecFlow.Steps
    {

        private readonly PlayerCharacterStepsContext _context;

        public PlayerCharacterSteps(PlayerCharacterStepsContext context) {
            _context = context; 
        }

        //[Given(@"I am new player")]
        //public void GivenIAmNewPlayer() {
        //    this.player = new PlayerCharacter();
        //    _context.player 
        //
        //}

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage) {
            _context.player.Hit(damage);
        }

        [Then(@"my health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int health) {
            Assert.Equal(health, _context.player.Health);
        }

        [Then(@"I should be dead")]
        public void ThenIShouldBeDead() {
            Assert.Equal(true, _context.player.IsDead);
        }

        [When(@"When I take (.*) damage")]
        public void WhenWhenITakeDamage(int damage) {
            _context.player.Hit(damage);
        }

        [Then(@"my health should be (.*)")]
        public void ThenMyHealthShouldBe(int health) {
            Assert.Equal(health, _context.player.Health);
        }

        [Given(@"I have damage resistence of (.*)")]
        public void GivenIHaveDamageResistenceOf(int damagaResistence) {
            _context.player.DamageResistence = damagaResistence;
        }

        [Given(@"I am an Elf")]
        public void GivenIAmAnElf() {
            _context.player.Race = "Elf";
        }

        //[Given(@"I have the following attributes")]
        //public void GivenIHaveTheFollowingAttributes(Table table) {
        //    var race = table
        //        .Rows
        //        .First( row => row["attribute"] == "Race")
        //        ["value"];
        //
        //    var resistance = table
        //        .Rows
        //        .First(row => row["attribute"] == "Resistance")
        //        ["value"];
        //
        //    this.player.Race = race;
        //    this.player.DamageResistence = int.Parse(resistance) ;
        //}

        //[Given(@"I have the following attributes")]
        //public void GivenIHaveTheFollowingAttributes(Table table) {
        //    var attributes = table.CreateInstance<PlayerAttributes>();
        //
        //    this.player.Race = attributes.Race;
        //    this.player.DamageResistence = attributes.Resistence;
        //}

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table) {
            dynamic attributes = table.CreateDynamicInstance();

            _context.player.Race = attributes.Race;
            _context.player.DamageResistence = attributes.Resistence;
        }

        [Given(@"My character class is set to (.*)")]
        public void GivenMyCharacterClassIsSetToHealer(CharacterClass characterClass) {
            _context.player.CharacterClass = characterClass;
        }

        [When(@"Cast a healing spell")]
        public void WhenCastAHealingSpell() {
            _context.player.CastHealingSpell();
        }

        [Given(@"I have the following magical items")]
        public void GivenIHaveTheFollowingMagicalItems(Table table) {

            // method  2
            IEnumerable<MagicalItem> magicalItems = table.CreateSet<MagicalItem>();
            _context.player.MagicalItems.AddRange(magicalItems);

            // method 3
            //dynamic magicalItems = table.CreateDynamicSet();
            //foreach (var item in magicalItems) {
            //    player.MagicalItems.Add(new MagicalItem {
            //        Name = item.name,
            //        Power = item.power,
            //        Value = item.value
            //    });
            //}
        }

        [Then(@"my total magica power should be (.*)")]
        public void ThenMyTotalMagicaPowerShouldBe(int expectedPower) {
            Assert.Equal(expectedPower, _context.player.MagicalPower);
        }

        [Given(@"I last slept (.* days ago)")]
        public void GivenILastSleptDaysAgo(DateTime lastSlept) {
            _context.player.LastSleepTime = lastSlept;
        }

        [When(@"read a restore health scroll")]
        public void WhenReadARestoreHealthScroll() {

        }

        [Given(@"I have the following weapons")]
        public void GivenIHaveTheFollowingWeapons(IEnumerable<Weapon> weapons) {

            _context.player.Weapons.AddRange(weapons);

        }

        [Then(@"my weapons should be worth (.*)")]
        public void ThenMyWeaponsShouldbeWorth(int value) {
            Assert.Equal(value , _context.player.WeaponsValue); 
        }

        ////////////////


        [Given(@"I'm an elf")]
        public void GivenIMAnElf() {


        }

        [Given(@"I have an amulet with a power of (.*)")]
        public void GivenIHaveAnAmuletWithAPowerOf(int power) {

            _context.player.MagicalItems.Add(
                new MagicalItem {
                    Name = "Amulet" ,
                    Power = power , 
                    }
                );

            _context.StartingMagicalPower = power; 
        }

        [When(@"I use a magical Amulet")]
        public void WhenIUseAMagicalAmulet() {
            _context
            .player
            .UseMagicalItem("Amulet");
        }

        [Then(@"the amulet power should not be reduced")]
        public void ThenTheAmuletPowerShouldNotBeReduced() {

            var expectedPower = _context.StartingMagicalPower;

            Assert.Equal(
                expectedPower , 
                _context
                .player
                .MagicalItems
                .First( x=>x.Name == "Amulet")
                .Power 
            );


        }












    }
}