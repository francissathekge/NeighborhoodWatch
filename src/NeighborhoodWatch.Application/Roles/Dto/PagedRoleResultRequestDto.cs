using Abp.Application.Services.Dto;

namespace NeighborhoodWatch.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

