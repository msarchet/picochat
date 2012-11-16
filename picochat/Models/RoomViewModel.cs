using picochat.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace picochat.Models
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public IList<MessageViewModel> Messages
        { 
            get 
            {
                using(var redis = new RedisClient())
                {
                    var client = redis.As<MessageViewModel>();
                    return client.Lists[String.Format("Messages:{0}", RoomName)];
                }
            } 
        }

        public IList<UserViewModel> Users
        {
            get
            {
                using (var redis = new RedisClient())
                {
                    var client = redis.As<UserViewModel>();
                    return client.Lists[String.Format("Users:{0}", RoomName)];
                }
            }
        }
    }

    public class RoomRepository
    {

        public static IList<RoomViewModel> Rooms 
        {
            get 
            {
                using(var redis = new RedisClient())
                {
                    var client = redis.As<RoomViewModel>();
                    return client.Lists["Rooms"];
                }
            }
        }
    }
}