using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Hero;
using BattleForAzeroth.Game.Widget.Number;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Equip.Paladin
{
    public class TruesilverChampion : BaseEquip
    {
        public override string Name => "真银圣剑";

        public override string BackgroudImage => "Paladin/TruesilverChampion.jpg";

        public override int Damage { get; set; } = 4;
        public override int Durable { get; set; } = 2;
        public override int Cost { get; set; } = 4;
        public override int InitialCost => 4;
        public override int InitialDamege => 4;
        public override Rarity Rare => Rarity.普通;

        public override List<ICardAbility> Abilities => new List<ICardAbility>() {
            new HeroAttackingDriver<
                Heal<PrimaryHeroFilter,Two>,
                InDeskFilter>()
        };

        public override string Describe => "每当你的英雄进攻时，为其恢复2点生命值。";
        public override Profession Profession => Profession.Paladin;
    }
}
