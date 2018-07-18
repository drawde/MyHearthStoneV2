using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Warlock
{
    public class Voidwalker : BaseServant
    {
        public override int Damage { get; set; }  = 1;
        public override int Life { get; set; }  = 3;
        public override int Cost { get; set; }  = 1;

        public override int InitialDamage => 1;
        public override int InitialLife => 3;
        public override int InitialCost => 1;
        
        public override int BuffLife { get; set; }  = 3;

        public override string Describe => "嘲讽。";

        public override Rarity Rare => Rarity.普通;

        public override List<ICardAbility> Abilities => new List<ICardAbility>() { };

        public override string BackgroudImage => "Classical/Voidwalker.jpg";

        public override string Name => "虚空行者";
        public override Profession Profession => Profession.Warlock;
        public override Race Race => Race.恶魔;
        public override bool HasTaunt => true;
    }
}
