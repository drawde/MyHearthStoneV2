using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_DireWolfAlpha() };

        public override string BackgroudImage { get; set; } = "WOW_TAL_008_D.png";

        public override string Name { get; set; } = "恐狼前锋";
        public override Profession Profession { get; set; } = Profession.Neutral;
        public override Race Race { get; set; } = Race.野兽;
    }
}
