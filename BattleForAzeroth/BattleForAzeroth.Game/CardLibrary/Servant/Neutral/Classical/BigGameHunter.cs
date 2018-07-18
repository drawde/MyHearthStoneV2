using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.Classical
{
    public class BigGameHunter : BaseServant
    {
        public override int Damage { get; set; }  = 4;
        public override int Life { get; set; }  = 2;
        public override int Cost { get; set; }  = 3;

        public override int InitialDamage => 4;
        public override int InitialLife => 2;
        public override int InitialCost => 3;
        
        public override int BuffLife { get; set; }  = 2;

        public override string Describe => "战吼：消灭一个攻击力大于或等于7的随从。";

        public override Rarity Rare => Rarity.史诗;

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new AllEnemyServantBattlecryDriver<Death<SecondaryServantFilter>>(),
        };

        public override string BackgroudImage => "W5_030_D.png";

        public override string Name => "王牌猎手";
        public override Profession Profession => Profession.Neutral;
    }
}
