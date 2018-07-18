using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class KoboldGeomancer : BaseServant
    {
        public override int Damage { get; set; }  = 2;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 2;

        public override int InitialDamage => 2;
        public override int InitialLife => 2;
        public override int InitialCost => 2;


        public override int BuffLife { get; set; }  = 2;
        public override string Describe => "法术伤害+1。";

        public override Rarity Rare => Rarity.普通;     

        public override string Name => "狗头人地卜师";
        public override string BackgroudImage => "Classical/KoboldGeomancer.jpg";

        public override Profession Profession => Profession.Neutral;
        public override int SpellPower => 1;
    }
}
