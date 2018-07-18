using BattleForAzeroth.Game.CardLibrary.CardAbility;
using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Warrior
{
    public class ShieldBlock : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "盾牌格挡";
        public override int Cost { get; set; }  = 3;
        public override int InitialCost => 3;
        public override string Describe => "获得5点护甲。抽1张牌。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver
                <
                    DoubleActionDriver
                    <
                        AddAmmo<PrimaryUserContextFilter,Five>,
                        DrawCard<PrimaryUserContextFilter,ONE>,
                        NullFilter
                    >>(),
            //new CA_ShieldBlock()
        };

        public override string BackgroudImage => "WOW_MISC_021_D_1.png";
        public override Profession Profession => Profession.Warrior;
    }
}
