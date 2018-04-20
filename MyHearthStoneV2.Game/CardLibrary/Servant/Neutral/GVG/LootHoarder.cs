using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.GVG
{
    public class LootHoarder : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 1;
        public override int InitialCost { get; set; } = 2;

        
        public override int BuffLife { get; set; } = 1;
        public override string Describe { get; set; } = "亡语：抽一张牌。";

        public override Rarity Rare => Rarity.普通;

        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>()
        {
            new DeathWhisperDriver<DrawCard<MainUserContextFilter,ONE>,InDeskFilter>(),            
        };


        public override string Name { get; set; } = "战利品贮藏者";
        public override string BackgroudImage { get; set; } = "W9_A058_D.png";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
