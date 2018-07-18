using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Number;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Paladin
{
    public class LayOnHands : BaseSpell
    {
        public override Rarity Rare => Rarity.史诗;

        public override string Name => "圣疗";
        public override int Cost { get; set; }  = 8;
        public override int InitialCost => 8;
        public override string Describe => "恢复8点生命。抽3张牌。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new AllTargetSpellDriver
            <
                DoubleAbility
                <
                    Heal<SecondaryFilter,Eight>,
                    DrawCard<PrimaryUserContextFilter,Three>
                >
            >(),
        };

        public override string BackgroudImage => "Paladin/LayOnHands.jpg";
        public override Profession Profession => Profession.Paladin;
    }
}
