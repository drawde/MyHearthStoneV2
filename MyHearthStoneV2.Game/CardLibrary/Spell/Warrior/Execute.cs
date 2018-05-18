using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Condition.Assert.Injured;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class Execute : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "斩杀";
        public override int Cost => 1;
        public override int InitialCost => 1;
        public override string Describe => "消灭一个受过伤害的敌方随从。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new SpellDriver_Single_AllEnemyServant<Assert<SecondaryCardIsInjured,Death<SecondaryServantFilter>,Null>>()
        };

        public override string BackgroudImage => "WoW_Chi_061_D.png";
        public override Profession Profession => Profession.Warrior;
    }
}
