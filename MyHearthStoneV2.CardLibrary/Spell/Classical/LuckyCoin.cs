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
        public CardLocation CardLocation = CardLocation.牌库;

        public Rarity Rare
        {
            get
            {
                return Rarity.普通;
            }
        }

        public List<ISpecialEffect> LstBuff = new List<ISpecialEffect>() {  };

        public string Name
        {
            get
            {
                return "幸运币";
            }
        }
    }
}
