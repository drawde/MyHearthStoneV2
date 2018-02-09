using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class Doomsayer : BaseServant
    {
        public override int Damage { get; set; } = 0;
        public override int Life { get; set; } = 7;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 0;
        public override int InitialLife { get; set; } = 7;
        public override int InitialCost { get; set; } = 2;

        public override int BuffLife { get; set; } = 7;

        public override string Describe { get; set; } = "在你的回合开始时，消灭所有随从。";

        public override Rarity Rare { get; set; } = Rarity.史诗;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>()
        {
            new MyTurnStartDriver<Death<AllServantFilter>>()            
        };

        public override string BackgroudImage { get; set; } = "Classical/Doomsayer.jpg";

        public override string Name { get; set; } = "末日预言者";
        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
