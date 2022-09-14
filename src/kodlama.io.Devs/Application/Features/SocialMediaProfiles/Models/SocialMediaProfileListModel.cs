using Application.Features.SocialMediaProfiles.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaProfiles.Models
{
    public class SocialMediaProfileListModel:BasePageableModel
    {
        public List<SocialMediaProfileListDto> Items { get; set; }
    }
}
