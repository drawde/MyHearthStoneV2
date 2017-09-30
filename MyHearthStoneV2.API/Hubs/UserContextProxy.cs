using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHearthStoneV2.API.Hubs
{
    public class UserContextProxy
    {
        public static List<SignalRUser> GetUsers()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                return redisClient.Get<List<SignalRUser>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRUser));
            }
        }

        public static List<ConversationRoom> GetRooms()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                return redisClient.Get<List<ConversationRoom>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRRoom));
            }
        }

        public static void Init()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRUser), new List<SignalRUser>());
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRRoom), new List<ConversationRoom>());
            }
        }


        public static void AddUser(SignalRUser user)
        {
            var _users = GetUsers();
            _users.Add(user);
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRUser), _users);
            }
        }

        public static void SetUser(SignalRUser user)
        {
            var Users = GetUsers();
            Users[Users.FindIndex(c => c.UserCode == user.UserCode)] = user;
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRUser), Users);
            }
        }

        public static void RemoveUser(SignalRUser user)
        {
            var Users = GetUsers();
            Users.Remove(Users.First(c => c.UserCode == user.UserCode));
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRUser), Users);
            }
        }

        public static void AddRoom(ConversationRoom room)
        {
            var Rooms = GetRooms();
            Rooms.Add(room);
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRRoom), Rooms);
            }
        }

        public static void SetRoom(ConversationRoom room)
        {
            var Rooms = GetRooms();
            Rooms.RemoveAt(Rooms.FindIndex(c => c.RoomName == room.RoomName));
            Rooms.Add(room);
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRRoom), Rooms);
            }
        }

        public static void RemoveRoom(ConversationRoom room)
        {
            var Rooms = GetRooms();
            Rooms.Remove(Rooms.First(c => c.RoomName == room.RoomName));
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SignalRRoom), Rooms);
            }
        }
    }
}