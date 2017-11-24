using MyHearthStoneV2.CardEnum;
using System.Collections.Generic;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.CardAbility;
using MyHearthStoneV2.CardLibrary.CardAbility.Other;

namespace MyHearthStoneV2.CardLibrary.Servant.Shaman.Classical
{
    [PropertyChangedNotification]
    public class Al_akir : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 8;
        public override CardLocation CardLocation { get; set; }

        public override List<BaseSpecialEffect> LstBuff { get; set; } = new List<BaseSpecialEffect>() { new Taunt(), new Windfury(), new Charge(), new HolyShield() };
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
    }
}
