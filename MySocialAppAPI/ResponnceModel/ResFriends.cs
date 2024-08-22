using System.Collections.Generic;

namespace MySocialAppAPI.ResponnceModel
{
    public class ResFriends
    {

        public ResFriends()
        {
            users = new List<ResUser>();
            reqUsers = new List<ResUser>();
            sendUsers = new List<ResUser>();
        }

        public List<ResUser> users { get; set; }
        public List<ResUser> reqUsers { get; set; }
        public List<ResUser> sendUsers { get; set; }
    }
}
