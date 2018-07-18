using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Event.GameProcess;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class JiaoXiaoDeZhongShi : BaseServant
    {
        public override int Damage { get; set; }  = 2;
        public override int Life { get; set; }  = 1;
        public override int Cost { get; set; }  = 1;

        public override int InitialDamage => 2;
        public override int InitialLife => 1;
        public override int InitialCost => 1;
        
        public override int BuffLife { get; set; }  = 1;

        public override string Describe => "战吼：在本回合中，使一个随从获得 +2 攻击力。";

        public override Rarity Rare => Rarity.普通;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new AllServantBattlecryDriver<
                ChangeDamage<SecondaryServantFilter,Two,Plus,InDeskFilter,
                            RestoreDamage<PrimaryServantFilter,Two,Minus,InDeskFilter,TurnEndEvent>>>()
        };

        public override string BackgroudImage => "W2_326_D.png";

        public override string Name => "叫嚣的中士";
        public override Profession Profession => Profession.Neutral;
    }
}
