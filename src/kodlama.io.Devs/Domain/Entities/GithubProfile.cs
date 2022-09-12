using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GithubProfile:Entity
    {
        public int UserId { get; set; }
        public string GithubUserName { get; set; }
        public virtual User? User { get; set; }

        public GithubProfile(int id,int userId, string githubUserName)
        {
            Id = id;
            UserId = userId;
            GithubUserName = githubUserName;
        }

        public GithubProfile()
        {

        }
    }
}
