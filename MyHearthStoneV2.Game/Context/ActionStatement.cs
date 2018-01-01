using MyHearthStoneV2.Game.CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Context
{
    public class ActionStatement
    {
        public int QueueIndex { get; set; } = 0;
        public Card TriggerCard { get; set; }
        public Card SourceCard { get; set; }
        public int TargetCardIndex { get; set; }
        public SpellCardAbilityTime SpellCardAbilityTime { get; set; }
    }
}
