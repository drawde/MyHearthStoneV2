using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;
using MyHearthStoneV2.Game.Widget.Number;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class NerubianEgg : BaseServant
    {
        public override int Damage { get; set; }  = 0;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 0;
        public override int InitialLife => 2;
        public override int InitialCost => 2;
        
        public override int BuffLife { get; set; }  = 2;

        public override string Describe => "亡语：召唤一个4/4的蛛魔。";

        public override Rarity Rare => Rarity.精良;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new DeathWhisperDriver<Summon<PrimaryUserContextFilter,NullFilter,AssignServantFilter<Nerubian>,AllPickFilter,ONE>,InDeskFilter>()
        };

        public override string BackgroudImage => "NAXX/NerubianEgg.jpg";

        public override string Name => "蛛魔之卵";
        public override bool CanAttack => false;
        public override Profession Profession => Profession.Neutral;
    }
}
