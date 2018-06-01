using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Game.Widget.Number;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class SludgeBelcher : BaseServant
    {
        public override int Damage => 3;
        public override int Life => 5;
        public override int Cost => 5;

        public override int InitialDamage => 3;
        public override int InitialLife => 5;
        public override int InitialCost => 5;

        public override int BuffLife => 5;

        public override string Describe => "嘲讽，亡语：召唤一个1/2并具有嘲讽的泥浆怪。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new DeathWhisperDriver<Summon<PrimaryUserContextFilter,NullFilter,AssignServantFilter<Slime>,AllPickFilter,ONE>,InDeskFilter>()
        };
        public override bool HasTaunt => true;
        public override string BackgroudImage => "NAXX/SludgeBelcher.png";

        public override string Name => "淤泥喷射者";
        public override bool CanAttack => false;
        public override Profession Profession => Profession.Neutral;
    }
}
