using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class Nerubian : BaseServant
    {
        public override int Damage { get; set; } = 4;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 4;

        public override int InitialDamage { get; set; } = 4;
        public override int InitialLife { get; set; } = 4;
        public override int InitialCost { get; set; } = 4;

        public override int BuffDamage { get; set; } = 4;
        public override int BuffLife { get; set; } = 4;
        public override int BuffCost { get; set; } = 4;

        public override bool IsDerivative { get; set; } = true;
        public override string Describe { get; set; } = "";

        public override Rarity Rare { get; set; } = Rarity.普通;

        //public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_ServantAttack() };
        public override string Name { get; set; } = "蛛魔";
        public override Profession Profession { get; set; } = Profession.Neutral;
        public override string BackgroudImage { get; set; } = "NAXX/Nerubian.jpg";
    }
}
