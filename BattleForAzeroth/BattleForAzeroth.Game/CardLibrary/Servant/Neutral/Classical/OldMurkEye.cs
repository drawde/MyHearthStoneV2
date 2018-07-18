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
using BattleForAzeroth.Game.Widget.Condition.RaceCondition;
using BattleForAzeroth.Game.Widget.Extract.Card;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class OldMurkEye : BaseServant
    {
        public override int Damage { get; set; }  = 2;
        public override int Life { get; set; }  = 4;
        public override int Cost { get; set; }  = 4;
        public override int InitialDamage => 2;
        public override int InitialLife => 4;
        public override int InitialCost => 4;
        public override int BuffLife { get; set; }  = 4;
        public override string Describe => "冲锋，在战场上每有一个其他鱼人便获得+1攻击力。";
        public override Rarity Rare => Rarity.传说;
        public override string Name => "老瞎眼";
        public override string BackgroudImage => "Bestiary_final2_D.png";
        public override Profession Profession => Profession.Neutral;
        public override Race Race => Race.鱼人;
        public override bool HasCharge => true;
        public OldMurkEye()
        {
            Abilities = new List<ICardAbility>()
            {
                new AuraDriver<
                    StandardAura<
                        ChangeDamage<TertiaryFilter,ExtractCardDamage<RaceFilter<Murloc>,InDeskFilter>,Plus,InDeskFilter,
                            RestoreDamage<TertiaryFilter,ExtractCardDamage<RaceFilter<Murloc>,InDeskFilter>,Minus,InDeskFilter,NullEvent>
                        >>,
                    InDeskFilter,
                    ServantInDeskEvent>(this)
            };
        }
    }
}
