using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Assert.Injured;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class Execute : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "斩杀";
        public override int Cost { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;
        public override string Describe { get; set; } = "消灭一个受过伤害的敌方随从。";

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new SpellDriver_Single_AllEnemyServant<Assert<SecondaryCardIsInjured,Death<SecondaryServantFilter>,Null>>()
        };

        public override string BackgroudImage { get; set; } = "WoW_Chi_061_D.png";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
