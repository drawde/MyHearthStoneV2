using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Aura;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.Servant;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class DireWolfAlpha : BaseServant
    {
        public override int Damage { get; set; }  = 2;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 2;
        public override int InitialLife => 2;
        public override int InitialCost => 2;
        
        public override int BuffLife { get; set; }  = 2;

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
