
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.CardAction;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Shaman.Classical
{
    public class Al_akir : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 8;
        public override CardLocation CardLocation { get; set; }

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new Taunt(), new Windfury(), new Charge(), new HolyShield(), new CA_ServantAttack() };
        public override string Describe
        {
            get
            {
                return "";
            }
        }

        public override Rarity Rare
        {
            get
            {
                return Rarity.传说;
            }
        }

        public override string Name
        {
            get
            {
                return "风领主奥拉基尔";
            }
        }
        public override string BackgroudImage { get; set; } = "W14_a190_D.png";
    }
}
