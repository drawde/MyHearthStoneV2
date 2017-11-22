

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

        public HS_Game CreateGame(string tableCode, string firstUserCode, string secondUserCode,string firstUserCardGroupCode,string secondUserCardGroupCode)
        {
            HS_Game game = null;
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {
                game = new HS_Game
                {
                    GameCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameCode),
                    AddTime = DateTime.Now,
                    CurrentRoundCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameRoundCode),
                    FirstUserCode = firstUserCode,
                    IsFirstUserWin = false,
                    NextRoundCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameRoundCode),
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
                    IsFirstUserRound = true,
                    RoundIndex = 0,
                    SecondUserCode = secondUserCode,
                    RoundCode = game.CurrentRoundCode,
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
