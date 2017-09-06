using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardSpecialEffect.Other;
using MyHearthStoneV2.CardSpecialEffect;

namespace MyHearthStoneV2.CardLibrary.Servant.Classical
{
    [PropertyChangedNotification]
    public class Al_akir : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 4;
        public override int Cost { get; set; } = 8;
        public override CardLocation CardLocation { get; set; }

        public override List<ISpecialEffect> LstBuff { get; set; } = new List<ISpecialEffect>() { new Taunt(), new Windfury(), new Charge(), new HolyShield() };
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
