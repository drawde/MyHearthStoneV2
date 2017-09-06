using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardMonitor;
using MyHearthStoneV2.CardSpecialEffect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Spell.Classical
{
    [PropertyChangedNotification]
    public class LuckyCoin: ISpell
    {

        public override Rarity Rare
        {
            get
            {
                return Rarity.普通;
            }
        }

        //public override List<ISpecialEffect> LstBuff { get; set; } = new List<ISpecialEffect>() { };

        public override string Name
        {
            get
            {
                return "幸运币";
            }
        }
    }
}
