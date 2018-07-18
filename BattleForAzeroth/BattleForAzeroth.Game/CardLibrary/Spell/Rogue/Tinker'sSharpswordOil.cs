using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Hero;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Rogue
{
    public class Tinker_sSharpswordOil : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "修补匠的磨刀油";
        public override int Cost { get; set; }  = 4;
        public override int InitialCost => 4;
        public override string Describe => "给你的武器+3攻击力，连击：给你的随从+3攻击力。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<
                    ComboDriver
                    <
                        UpgradeWeapon<PrimaryHeroFilter,Three,Zero>,
                        DoubleActionDriver<UpgradeWeapon<PrimaryHeroFilter,Three,Zero>,AddDamage<RandomPrimaryServantFilter,Three>,NullFilter>,NullFilter
                    >>(),
            //new CA_Tinker_sSharpswordOil()
        };

        public override string BackgroudImage => "Classical/Tinker_sSharpswordOil.jpg";
        public override Profession Profession => Profession.Rogue;
    }
}
