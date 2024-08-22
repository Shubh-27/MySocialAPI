using MySocialAppAPI.BAL.Interface;
using MySocialAppAPI.RequestModel;
using MySocialAppAPI.ResponnceModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace MySocialAppAPI.Controllers
{
    [Route("v1/MySocial/Post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IDisplayPost displayPost;

        public PostController(IDisplayPost _displayPost)
        {
            this.displayPost = _displayPost;
        }

        [HttpGet("{id}")]
        public List<ResPost> GetPost(int id)
        {
            return this.displayPost.Getpost(id);
        }

        [HttpGet("User/{id}")]
        public ResFriends GetUsers(int id)
        {
            return this.displayPost.GetUser(id);
        }

        [HttpGet("Friends/{id}")]
        public List<ResUser> GetFriends(int id)
        {
            return this.displayPost.GetFriends(id);
        }

        [HttpGet("Profile/{id}")]
        public List<ResPost> GetMyPost(int id)
        {
            return this.displayPost.GetMyPost(id);
        }


        [HttpPost("AddFriend")]
        public bool AddFriend(ReqID reqID)
        {
            return this.displayPost.AddFriend(reqID.id, reqID.fid);
        }


        [HttpPost("AcceptFriend")]
        public bool AcceptFriend(ReqID reqID)
        {
            return this.displayPost.AcceptFriend(reqID.id, reqID.fid);
        }


        [HttpPost("RejectFriend")]
        public bool RejectFriend(ReqID reqID)
        {
            return this.displayPost.RejectFriend(reqID.id, reqID.fid);
        }


        [HttpPost("Post")]
        public bool Putpost(ReqPost post)
        {
            return this.displayPost.Putpost(post.Posttext, post.Userid);
        }


        [HttpPut("EditPost")]
        public bool EditPost(ReqEditPost editPost)
        {
            return this.displayPost.EditPost(editPost.Posttext, editPost.Postid);
        }


        [HttpPost("DeletePost")]
        public bool DeletePost(ReqDeletePost deletePost)
        {
            return this.displayPost.DeletePost(deletePost.Postid);
        }
    }
}
