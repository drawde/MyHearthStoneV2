using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Event.GameProcess;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class JiaoXiaoDeZhongShi : BaseServant
    {
        public override int Damage => 2;
        public override int Life => 1;
        public override int Cost => 1;

        public override int InitialDamage => 2;
        public override int InitialLife => 1;
        public override int InitialCost => 1;
        
        public override int BuffLife => 1;

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
