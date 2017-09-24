using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHearthStoneV2.API.Hubs
{
    public class UserContextProxy
    {
        public static List<SignalRUser> Users
        {
            get
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    return redisClient.Get<List<SignalRUser>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRUser));
                }
            }
            set
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRUser), value);
                }
            }
        }

        public static List<ConversationRoom> Rooms
        {
            get
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    return redisClient.Get<List<ConversationRoom>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRRoom));
                }
            }
            set
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRRoom), value);
                }
            }
        }

        public static void Init()
        {
            Users = new List<SignalRUser>();
            Rooms = new List<ConversationRoom>();
        }


        public static void AddUser(SignalRUser user)
        {
            var _users = Users;
            _users.Add(user);
            Users = _users;
        }

        public static void SetUser(SignalRUser user)
        {
            Users[Users.FindIndex(c => c.UserCode == user.UserCode)] = user;
        }

        public static void RemoveUser(SignalRUser user)
        {
            var _users = Users;
            _users.Remove(_users.First(c => c.UserCode == user.UserCode));
            Users = _users;
        }

        public static void AddRoom(ConversationRoom room)
        {
            var _rooms = Rooms;
            _rooms.Add(room);
            Rooms = _rooms;
        }

        public static void SetRoom(ConversationRoom room)
        {
            Rooms.RemoveAt(Rooms.FindIndex(c => c.RoomName == room.RoomName));
            Rooms.Add(room);
        }

        public static void RemoveRoom(ConversationRoom room)
        {
            var _rooms = Rooms;
            _rooms.Remove(_rooms.First(c => c.RoomName == room.RoomName));
            Rooms = _rooms;
        }
    }
}