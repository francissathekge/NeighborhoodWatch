using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.AddressService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.AddressService
{
    public class AddressAppService : CrudAppService<Address, AddressDto, Guid, PagedAndSortedResultRequestDto>
    {
        private readonly IRepository<Address, Guid> _AddRepository;
        public AddressAppService(IRepository<Address, Guid> repository) : base(repository)
        {
            _AddRepository = repository;
        }
    }
}
