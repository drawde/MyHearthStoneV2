using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.SpecialEffect.WarCry;
using MyHearthStoneV2.CardMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Servant.Classical
{
    [PropertyChangedNotification]
    public class JiaoXiaoDeZhongShi : BaseServant, ChangeBody
    {
        private int _damage = 2;
        private int _life = 1;
        private int _cost = 1;
        private CardLocation _cardLocation = CardLocation.牌库;

        private string _gameID;
        private string _userCode;
        private string _cardID;

        public string CardID
        {
            get
            {
                return _cardID;
            }

            set
            {
                _cardID = value;
            }
        }
        public string GameID
        {
            get
            {
                return _gameID;
            }

            set
            {
                _gameID = value;
            }
        }

        public string UserCode
        {
            get
            {
                return _userCode;
            }

            set
            {
                _userCode = value;
            }
        }
        public CardLocation CardLocation
        {
            get
            {
                return _cardLocation;
            }

            set
            {
                _cardLocation = value;
            }
        }
        public string Describe
        {
            get
            {
                return "";
            }
        }

        public Rarity Rare
        {
            get
            {
                return Rarity.普通;
            }
        }

        private List<BuffTime> _lstBuff = new List<BuffTime>();
        public List<BuffTime> LstBuff
        {
            get
            {
                return _lstBuff;
            }

            set
            {
                _lstBuff = value;
            }
        }
        private int _chessboardIndex = -1;
        public int ChessboardIndex
        {
            get
            {
                return _chessboardIndex;
            }

            set
            {
                _chessboardIndex += value;
            }
        }
        public int Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage += value;
            }
        }

        public int Life
        {
            get
            {
                return _life;
            }

            set
            {
                _life = value;
            }
        }

        public string Name
        {
            get
            {
                return "叫嚣的中士";
            }
        }

        public int Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost += value;
            }
        }

        

        public void InChessboard()
        {
            LstBuff.Add(new BuffTime(typeof(ChangeBody), BuffTimeLimit.己方回合结束));
        }

        public void OutChessboard()
        {
        }

        public void Spell()
        {
        }
        
    }
}
