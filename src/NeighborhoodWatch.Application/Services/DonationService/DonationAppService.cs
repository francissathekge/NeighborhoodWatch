using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.DonationService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.DonationService
{
    public class DonationAppService : CrudAppService<Donation, DonationDto, Guid, PagedAndSortedResultRequestDto>
    {
        private readonly IRepository<Donation, Guid> _donationRepository;
        public DonationAppService(IRepository<Donation, Guid> repository) : base(repository)
        {
            this._donationRepository = repository;
        }
    }
}
