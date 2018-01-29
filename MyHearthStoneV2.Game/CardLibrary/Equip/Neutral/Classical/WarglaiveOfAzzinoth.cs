using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer;

namespace MyHearthStoneV2.Game.CardLibrary.Equip.Neutral.Classical
{
    public class WarglaiveOfAzzinoth: BaseEquip
    {
        public override string Name { get; set; } = "埃辛诺斯战刃";

        public override string BackgroudImage { get; set; } = "W19_a256_D.png";

        public override int Damage { get; set; } = 3;
        public override int Durable { get; set; } = 3;


        public override int BuffDamage { get; set; } = 3;
        public override int InitialDamege { get; set; } = 3;

        public override bool IsDerivative => true;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_WarglaiveOfAzzinoth() };

        public override string Describe { get; set; } = "攻击目标是随从时，沉默该随从；攻击目标是英雄时，去除所有奥秘，无视护甲";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
