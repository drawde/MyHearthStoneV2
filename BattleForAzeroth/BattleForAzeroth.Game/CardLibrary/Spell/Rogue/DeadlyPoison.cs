using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Rogue
{
    public class DeadlyPoison : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "致命药膏";
        public override int Cost { get; set; }  = 1;
        public override int InitialCost => 1;
        public override string Describe => "使你的武器获得+2攻击力。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<UpgradeWeapon<PrimaryHeroFilter,Two,Zero>>()
        };

        public override string BackgroudImage => "Classical/DeadlyPoison.jpg";
        public override Profession Profession => Profession.Rogue;
    }
}
