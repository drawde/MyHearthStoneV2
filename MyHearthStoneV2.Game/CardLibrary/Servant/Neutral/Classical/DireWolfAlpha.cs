using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.GameProcess;
using MyHearthStoneV2.Game.Event.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class DireWolfAlpha : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        
        public override int BuffLife { get; set; } = 2;

        public override string Describe { get; set; } = "相邻的随从获得+1攻击力。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; }
        public DireWolfAlpha()
        {
            Abilities = new List<ICardAbility>()
            {
                new AuraDriver<
                    StandardAura<
                        ChangeDamage<MainCardBothSidesFilter,ONE,ONE,Plus,InDeskFilter,
                            RestoreDamage<MainServantFilter,ONE,ONE,Minus,InDeskFilter,NullEvent>
                        >>,
                    InDeskFilter,
                    ServantInDeskEvent>(this)
            };
        }
        public override string BackgroudImage { get; set; } = "WOW_TAL_008_D.png";

        public override string Name { get; set; } = "恐狼前锋";
        public override Profession Profession { get; set; } = Profession.Neutral;
        public override Race Race { get; set; } = Race.野兽;
    }
}
