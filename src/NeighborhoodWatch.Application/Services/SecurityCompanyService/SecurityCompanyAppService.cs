using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.SecurityCompanyService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.SecurityCompanyService
{
    public class SecurityCompanyAppService : CrudAppService<SecurityCompany, SecurityCompanyDto, Guid, PagedAndSortedResultRequestDto>
    {
        private readonly IRepository<SecurityCompany, Guid> _securityCompanyRepository;
        public SecurityCompanyAppService(IRepository<SecurityCompany, Guid> repository) : base(repository)
        {
            this._securityCompanyRepository = repository;
        }
    }
}
