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
    public class SocialMediaProfile:Entity
    {
        public int UserId { get; set; }
        public string SocialMediaUserName { get; set; }
        public string ProfileUrl { get; set; }
        public virtual User? User { get; set; }

        public SocialMediaProfile(int id,int userId, string socialMediaUserName)
        {
            Id = id;
            UserId = userId;
            SocialMediaUserName = socialMediaUserName;
        }

        public SocialMediaProfile()
        {

        }
    }
}
