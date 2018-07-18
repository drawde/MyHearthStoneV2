using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.CardLibrary.CardAction.Controler;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.Spell.Neutral.Classical;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Servant.Neutral.TOC
{
    public class TombPillager : BaseServant
    {
        public override int Damage { get; set; }  = 5;
        public override int Life { get; set; }  = 4;
        public override int Cost { get; set; }  = 4;

        public override int InitialDamage => 5;
        public override int InitialLife => 4;
        public override int InitialCost => 4;

        public override int BuffLife { get; set; }  = 4;
        public override string Describe => "亡语：将一个幸运币置入你的手牌。";

        public override Rarity Rare => Rarity.普通;

        public override List<ICardAbility> Abilities => new List<ICardAbility>() { new DeathWhisperDriver<CreateNewGenericCardInHandAction<LuckyCoin>, InDeskFilter>() };

        public override string Name => "盗墓匪贼";
        public override Profession Profession => Profession.Rogue;
        public override string BackgroudImage => "TOC/TombPillager.jpg";
    }
}
