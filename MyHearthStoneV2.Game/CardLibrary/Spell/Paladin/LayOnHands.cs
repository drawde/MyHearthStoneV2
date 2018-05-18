using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Number;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Paladin
{
    public class LayOnHands : BaseSpell
    {
        public override Rarity Rare => Rarity.史诗;

        public override string Name => "圣疗";
        public override int Cost => 8;
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
