using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace picochat.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public UsersStatus UserStatus { get; set; }
        public IList<string> ConnectionIDs
        {
            get
            {
                using (var redis = new RedisClient())
                {
                    var client = redis.As<string>();
                    return client.Lists[String.Format("ConnectionIDs:{0}", UserName)];
                }
            }
        }


    }

    public enum UsersStatus
    {
        Online,
        Away,
        Invisible
    }
}
