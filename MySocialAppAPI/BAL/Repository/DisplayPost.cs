using MySocialAppAPI.BAL.Interface;
using MySocialAppAPI.ResponnceModel;
using MySocialAppAPI.TenantDB;
using System.Collections.Generic;
using System.Linq;

namespace MySocialAppAPI.BAL.Repository
{
    public class DisplayPost : IDisplayPost
    {
        private readonly MySocialAppDBContext _context;

        public DisplayPost(MySocialAppDBContext context)
        {
            _context = context;
        }
        public List<ResPost> Getpost(int id)
        {
            
            List<ResPost> posts = new List<ResPost>();

            var friends = _context.Friends.ToList();

            var fromUsers = friends.Where(i => i.ToUserId.Equals(id) & i.Status == true).ToList();
            var toUsers = friends.Where(i => i.FromUserId.Equals(id) & i.Status == true).ToList();
            var totalUser = fromUsers.Select(i => i.FromUserId).Concat(toUsers.Select(i => i.ToUserId)).ToList();
            totalUser.Add(id);

            var Posts = _context.Posts.Where(i => totalUser.Any(y => y == i.UserId)).OrderByDescending(i => i.CreatedDateTime).ToList();

            var userData = _context.MySocials.Where(i => totalUser.Any(y => y == i.Id)).ToList();


            foreach (var item in Posts)
            {
                var post = new ResPost();
                post.UserId = item.UserId;
                post.PostText = item.PostText;
                post.CreatedDateTime = item.CreatedDateTime;
                post.PostId = item.PostId;
                post.Name = userData.SingleOrDefault(i => i.Id == item.UserId).Name;
                post.Username = userData.SingleOrDefault(i => i.Id == item.UserId).Username;
                posts.Add(post);
            }
            return posts;
        }
        public bool Putpost(string posttext, int id)
        {
            
            Post post = new Post();
            post.PostText = posttext;
            post.UserId = id;
            post.User = _context.MySocials.Where(i => i.Id == id).SingleOrDefault();
            _context.Posts.Add(post);
            _context.SaveChanges();
            return true;
        }
        public ResFriends GetUser(int id)
        {
            
            ResFriends reqfriend = new ResFriends();

            var friends = _context.Friends.ToList();
            var data2 = _context.MySocials.Where(i => i.Id != id).ToList();


            var fromUsers = friends.Where(i => i.ToUserId.Equals(id)).ToList();
            var toUsers = friends.Where(i => i.FromUserId.Equals(id)).ToList();
            var totalUser = fromUsers.Select(i => new { id = i.FromUserId, status = i.Status }).Concat(toUsers.Select(i => new { id = i.ToUserId, status = i.Status })).ToList();
            var friend = totalUser.Where(i => i.status == true).Select(i => i.id).ToList();
            var data = data2.Where(i => friend.All(y => y != i.Id)).ToList();


            var users = data.Where(i => totalUser.All(y => y.id != i.Id)).ToList();
            foreach (var item in users)
            {
                var user = new ResUser();
                user.UserId = item.Id;
                user.Username = item.Username;
                reqfriend.users.Add(user);
            }

            var reqUsers = data.Where(i => fromUsers.Any(y => y.FromUserId.Equals(i.Id))).ToList();
            foreach (var item in reqUsers)
            {
                var user = new ResUser();
                user.UserId = item.Id;
                user.Username = item.Username;
                reqfriend.reqUsers.Add(user);
            }

            var sendUsers = data.Where(i => toUsers.Any(y => y.ToUserId.Equals(i.Id))).ToList();
            foreach (var item in sendUsers)
            {
                var user = new ResUser();
                user.UserId = item.Id;
                user.Username = item.Username;
                reqfriend.sendUsers.Add(user);
            }

            return reqfriend;
        }
        public List<ResUser> GetFriends(int id)
        {
            
            List<ResUser> friend = new List<ResUser>();

            var friends = _context.Friends.ToList();
            var data = _context.MySocials.Where(i => i.Id != id).ToList();

            var fromUsers = friends.Where(i => i.ToUserId.Equals(id)).ToList();
            var toUsers = friends.Where(i => i.FromUserId.Equals(id)).ToList();
            var totalUser = fromUsers.Select(i => new { id = i.FromUserId, status = i.Status }).Concat(toUsers.Select(i => new { id = i.ToUserId, status = i.Status })).ToList();
            var friendid = totalUser.Where(i => i.status == true).Select(i => i.id).ToList();

            var users = data.Where(i => friendid.Any(y => y == i.Id)).ToList();
            foreach (var item in users)
            {
                var user = new ResUser();
                user.UserId = item.Id;
                user.Username = item.Username;
                friend.Add(user);
            }
            return friend;
        }
        public bool AddFriend(int id, int fid)
        {
            
            Friend friend = new Friend();
            friend.FromUserId = id;
            friend.ToUserId = fid;
            friend.Status = false;
            _context.Add(friend);
            _context.SaveChanges();
            return true;
        }
        public bool AcceptFriend(int id, int fid)
        {
            
            var friend = _context.Friends.Where(i => i.FromUserId.Equals(fid) && i.ToUserId.Equals(id)).SingleOrDefault();
            friend.Status = true;
            _context.SaveChanges();
            return true;

        }
        public bool RejectFriend(int id, int fid)
        {
            
            var friend = _context.Friends.Where(i => (i.FromUserId.Equals(fid) && i.ToUserId.Equals(id))||(i.FromUserId.Equals(id) && i.ToUserId.Equals(fid))).SingleOrDefault();
            _context.Friends.Remove(friend);
            _context.SaveChanges();
            return true;

        }
        public List<ResPost> GetMyPost(int id)
        {
            
            List<ResPost> posts = new List<ResPost>();

            var Posts = _context.Posts.Where(i => i.UserId == id).OrderByDescending(i => i.CreatedDateTime).ToList();

            var userData = _context.MySocials.Where(i => i.Id == id).ToList();

            foreach (var item in Posts)
            {
                var post = new ResPost();
                post.UserId = item.UserId;
                post.PostText = item.PostText;
                post.CreatedDateTime = item.CreatedDateTime;
                post.PostId = item.PostId;
                post.Name = userData.SingleOrDefault(i => i.Id == item.UserId).Name;
                post.Username = userData.SingleOrDefault(i => i.Id == item.UserId).Username;
                posts.Add(post);
            }
            return posts;
        }
        public bool EditPost(string posttext, int postid)
        {
            

            var post = _context.Posts.Where(i => i.PostId == postid).SingleOrDefault();
            post.PostText = posttext;
            _context.SaveChanges();
            return true;
        }
        public bool DeletePost(int postid)
        {
            

            var post = _context.Posts.Where(i => i.PostId == postid).SingleOrDefault();
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return true;
        }
    }
}
