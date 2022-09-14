using Application.Features.SocialMediaProfiles.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaProfiles.Queries.GetListSocialMediaProfilesQuery
{
    public class GetListSocialMediaProfileQuery:IRequest<SocialMediaProfileListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSocialMediaProfileQueryHandler:IRequestHandler<GetListSocialMediaProfileQuery,SocialMediaProfileListModel>
        {
            private readonly ISocialMediaProfileRepository _socialMediaProfileRepository;
            private readonly IMapper _mapper;

            public GetListSocialMediaProfileQueryHandler(ISocialMediaProfileRepository socialMediaProfileRepository, IMapper mapper)
            {
                _socialMediaProfileRepository = socialMediaProfileRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaProfileListModel> Handle(GetListSocialMediaProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMediaProfile> socialMediaProfiles = await _socialMediaProfileRepository.GetListAsync(
                    include: s => s.Include(s => s.User),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                SocialMediaProfileListModel mappadSocialMediaListModel = _mapper.Map<SocialMediaProfileListModel>(socialMediaProfiles);
                return mappadSocialMediaListModel;
            }
        }
    }
}
