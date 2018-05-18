using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class DireWolfAlpha : BaseServant
    {
        public override int Damage => 2;
        public override int Life => 2;
        public override int Cost => 2;

        public override int InitialDamage => 2;
        public override int InitialLife => 2;
        public override int InitialCost => 2;
        
        public override int BuffLife => 2;

        public override string Describe => "相邻的随从获得+1攻击力。";

        public override Rarity Rare => Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; }
        public DireWolfAlpha()
        {
            Abilities = new List<ICardAbility>()
            {
                new AuraDriver<
                    StandardAura<
                        ChangeDamage<PrimaryCardBothSidesFilter,ONE,Plus,InDeskFilter,
                            RestoreDamage<PrimaryServantFilter,ONE,Minus,InDeskFilter,NullEvent>
                        >>,
                    InDeskFilter,
                    ServantInDeskEvent>(this)
            };
        }
        public override string BackgroudImage => "WOW_TAL_008_D.png";

        public override string Name => "恐狼前锋";
        public override Profession Profession => Profession.Neutral;
        public override Race Race => Race.野兽;
    }
}
