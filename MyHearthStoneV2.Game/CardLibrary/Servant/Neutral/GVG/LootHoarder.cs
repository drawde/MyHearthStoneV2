using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public override int BuffDamage { get; set; } = 2;
        public override int BuffLife { get; set; } = 1;
        public override int BuffCost { get; set; } = 2;
        public override string Describe
        {
            get
            {
                return "亡语：抽一张牌。";
            }
        }

        public override Rarity Rare
        {
            get
            {
                return Rarity.普通;
            }
        }

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new DrawCard() { DrawCount = 1, AbilityType = AbilityType.亡语 } };


        public override string Name { get; set; } = "战利品贮藏者";
        public override string BackgroudImage { get; set; } = "W9_A058_D.png";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
