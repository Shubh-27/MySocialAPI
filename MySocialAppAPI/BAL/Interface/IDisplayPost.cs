using MySocialAppAPI.ResponnceModel;
using System.Collections.Generic;

namespace MySocialAppAPI.BAL.Interface
{
    public interface IDisplayPost
    {
        public List<ResPost> Getpost(int id);
        public List<ResPost> GetMyPost(int id);
        public bool Putpost(string posttext, int id);
        public bool EditPost(string posttext, int postid);
        public bool DeletePost(int postid);
        public ResFriends GetUser(int id);
        public List<ResUser> GetFriends(int id);
        public bool AddFriend(int id, int fid);
        public bool AcceptFriend(int id, int fid);
        public bool RejectFriend(int id, int fid);
    }
}
