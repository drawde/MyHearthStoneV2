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

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class MurlocWarleader : BaseServant
    {
        public override int Damage { get; set; }  = 3;
        public override int Life { get; set; }  = 3;
        public override int Cost { get; set; }  = 3;
        public override int InitialDamage => 3;
        public override int InitialLife => 3;
        public override int InitialCost => 3;
        public override int BuffLife { get; set; }  = 3;
        public override string Describe => "所有其他鱼人获得+2/+1。";
        public override Rarity Rare => Rarity.史诗;
        public override string Name => "鱼人领军";
        public override string BackgroudImage => "W18_a149_D_1.png";
        public override Profession Profession => Profession.Neutral;
        public override Race Race => Race.鱼人;
        public override List<ICardAbility> Abilities { get; set; }
        public MurlocWarleader()
        {
            Abilities = new List<ICardAbility>()
            {
                new AuraDriver<
                    StandardAura<
                        ChangeDamageAndLife<RaceFilter<Murloc>,Two,ONE,Plus,InDeskFilter,
                            RestoreDamageAndLife<RaceFilter<Murloc>,Two,ONE,Minus,InDeskFilter,NullEvent>
                        >>,
                    InDeskFilter,
                    ServantInDeskEvent>(this)
            };
        }
    }
}
