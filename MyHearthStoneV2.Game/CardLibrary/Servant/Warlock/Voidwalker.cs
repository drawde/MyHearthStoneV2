using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warlock
{
    public class Voidwalker : BaseServant
    {
        public override int Damage { get; set; } = 1;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 1;

        public override int InitialDamage { get; set; } = 1;
        public override int InitialLife { get; set; } = 3;
        public override int InitialCost { get; set; } = 1;

        public override int BuffDamage { get; set; } = 1;
        public override int BuffLife { get; set; } = 3;
        public override int BuffCost { get; set; } = 1;

        public override string Describe { get; set; } = "嘲讽。";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new Taunt() };

        public override string BackgroudImage { get; set; } = "Classical/Voidwalker.jpg";

        public override string Name { get; set; } = "虚空行者";
        public override Profession Profession { get; set; } = Profession.Warlock;
        public override Race Race { get; set; } = Race.恶魔;
    }
}
