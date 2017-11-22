using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.Monitor;

namespace MyHearthStoneV2.CardLibrary.Spell.Neutral.Classical
{
    [PropertyChangedNotification]
    public class LuckyCoin: BaseSpell
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
