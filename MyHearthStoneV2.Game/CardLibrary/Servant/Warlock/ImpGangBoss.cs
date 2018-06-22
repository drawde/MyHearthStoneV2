using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;
using MyHearthStoneV2.Game.Widget.Number;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warlock
{
    public class ImpGangBoss : BaseServant
    {
        public override int Damage { get; set; }  = 2;
        public override int Life { get; set; }  = 4;
        public override int Cost { get; set; }  = 3;

        public override int InitialDamage => 2;
        public override int InitialLife => 4;
        public override int InitialCost => 3;
        
        public override int BuffLife { get; set; }  = 4;

        public override string Describe => "每当他受到伤害的时候，召唤一只1/1的小鬼。";

        public override Rarity Rare => Rarity.普通;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new HurtDriver<Summon<PrimaryUserContextFilter,NullFilter,AssignServantFilter<Imp>,AllPickFilter,ONE>,InDeskFilter>(),            
        };

        public override string BackgroudImage => "BlackrockMountain/ImpGangBoss.jpg";

        public override string Name => "小鬼首领";
        public override Profession Profession => Profession.Warlock;
        public override Race Race => Race.恶魔;
    }
}
