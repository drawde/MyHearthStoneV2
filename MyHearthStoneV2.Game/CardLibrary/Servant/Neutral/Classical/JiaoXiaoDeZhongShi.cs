using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.Event.GameProcess;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class JiaoXiaoDeZhongShi : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 1;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;
        
        public override int BuffLife { get; set; } = 1;

        public override string Describe { get; set; } = "战吼：在本回合中，使一个随从获得 +2 攻击力。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new AllServantBattlecryDriver<
                ChangeDamage<SecondaryServantFilter,Two,ONE,Plus,InDeskFilter,
                            RestoreDamage<MainServantFilter,Two,ONE,Minus,InDeskFilter,TurnEndEvent>>>()
        };

        public override string BackgroudImage { get; set; } = "W2_326_D.png";

        public override string Name { get; set; } = "叫嚣的中士";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
