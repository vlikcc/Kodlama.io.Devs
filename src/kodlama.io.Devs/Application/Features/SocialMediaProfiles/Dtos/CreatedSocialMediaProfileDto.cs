using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaProfiles.Dtos
{
    public class CreatedSocialMediaProfileDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SocialMediaUserName { get; set; }
        public string ProfileUrl { get; set; }
    }
}
