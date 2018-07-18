using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Context;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.Cache
{
    public interface IGameCache
    {
        GameContext GetContext(string gameCode);
        void SetContext(GameContext gameContext);
        void RemoveContext(GameContext ctl);
        List<Card> GetAllCard();

    }
}
