using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.NAXX
{
    public class Nerubian : BaseServant
    {
        public override int Damage { get; set; }  = 4;
        public override int Life { get; set; }  = 4;
        public override int Cost { get; set; }  = 4;

        public override int InitialDamage => 4;
        public override int InitialLife => 4;
        public override int InitialCost => 4;
        
        public override int BuffLife { get; set; }  = 4;

        public override bool IsDerivative => true;
        public override string Describe => "";

        public override Rarity Rare => Rarity.普通;

        //public override List<BaseCardAbility> Abilities => new List<BaseCardAbility>() { new CA_ServantAttack() };
        public override string Name => "蛛魔";
        public override Profession Profession => Profession.Neutral;
        public override string BackgroudImage => "NAXX/Nerubian.jpg";
    }
}
