

using System;
using System.Linq;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.ShortCodeBll;

namespace MyHearthStoneV2.BLL
{
    public class GameBll : BaseBLL<HS_Game>
    {
        private IRepository<HS_Game> _repository = new Repository<HS_Game>();
        private GameBll()
        {
        }
        public static GameBll Instance = new GameBll();

        /// <summary>
        /// 创建一个游戏（数据库层面）
        /// </summary>
        /// <param name="tableCode"></param>
        /// <param name="firstUserCode"></param>
        /// <param name="secondUserCode"></param>
        /// <param name="firstUserCardGroupCode"></param>
        /// <param name="secondUserCardGroupCode"></param>
        /// <returns></returns>
        public HS_Game CreateGame(string tableCode, string firstUserCode, string secondUserCode,string firstUserCardGroupCode,string secondUserCardGroupCode)
        {
            HS_Game game = null;
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {
                game = new HS_Game
                {
                    GameCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameCode),
                    AddTime = DateTime.Now,
                    CurrentTurnCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameTurnCode),
                    FirstUserCode = firstUserCode,
                    IsFirstUserWin = false,
                    NextTurnCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameTurnCode),
                    SecondUserCode = secondUserCode,
                    FirstUserCardGroupCode = firstUserCardGroupCode,
                    SecondUserCardGroupCode = secondUserCardGroupCode,
                    TableCode = tableCode,
                    FirstUserIsOnline = true,
                    SecondUserIsOnline = true
                };
                context.hs_game.Add(game);

                HS_GameRecord record = new HS_GameRecord
                {
                    AddTime = game.AddTime,
                    GameContext = "",
                    FirstUserCode = firstUserCode,
                    GameCode = game.GameCode,
                    IsFirstUserTurn = true,
                    TurnIndex = 0,
                    SecondUserCode = secondUserCode,
                    TurnCode = game.CurrentTurnCode,
                    FunctionName = "CreateGame"
                };
                context.hs_gamerecord.Add(record);
                context.SaveChanges();
            }
            return game;
        }

        public HS_Game GetGame(string gameCode)
        {
            return _repository.GetList(c => c.GameCode == gameCode).Result.Items.ToList().First();
        }

        public HS_Game GetGameByTableCode(string tableCode)
        {
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {
                return context.hs_game.AsNoTracking().FirstOrDefault(c => c.TableCode == tableCode);
            }                
        }
    }
}
