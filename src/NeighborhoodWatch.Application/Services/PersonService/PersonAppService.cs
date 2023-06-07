using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Runtime.Session;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieListAbpApp.Domain;
using MovieListAbpApp.Services.PersonService.Dtos;
using NeighborhoodWatch.Authorization.Users;
using NeighborhoodWatch.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListAbpApp.Services.PersonService
{
    public class PersonAppService : ApplicationService, IPersonAppService
    {
        private readonly IRepository<Person, Guid> _PersonRepository;
        private readonly IRepository<Address, Guid> _addressRepository;
        private readonly UserManager _userManager;

        public PersonAppService(IRepository<Person, Guid> personRepository, UserManager userManager,
            IRepository<Address, Guid> addressRepository)
        {
            _PersonRepository = personRepository;
            _userManager = userManager;
            _addressRepository = addressRepository;
        }
        [HttpPost]
        public async Task<PersonDto> CreateAsync(PersonDto input)
        {
            var address = ObjectMapper.Map<Address>(input.Address);

            var addressDB = await _addressRepository.InsertAsync(address);

            var person = ObjectMapper.Map<Person>(input);
            person.User = await CreateUser(input);
            person.Address = addressDB;
            return ObjectMapper.Map<PersonDto>(
                await _PersonRepository.InsertAsync(person));
        }
        [HttpGet]
        public async Task<List<PersonDto>> GetAllAsync()
        {
            var query = _PersonRepository.GetAllIncluding(m => m.User,mbox=> mbox.Address).ToList();
            return ObjectMapper.Map<List<PersonDto>>(query);
        }
        [HttpGet]
        public async Task<PersonDto> GetAsync(Guid id)
        {
            var query = _PersonRepository.GetAllIncluding(m => m.User, mbox => mbox.Address).FirstOrDefault(x => x.Id == id);
            return ObjectMapper.Map<PersonDto>(query);
        }
        [HttpPut]
        public async Task<PersonDto> UpdateAsync(PersonDto input)
        {
            var person = _PersonRepository.Get(input.Id);
            var updt = await _PersonRepository.UpdateAsync(ObjectMapper.Map(input, person));
            return ObjectMapper.Map<PersonDto>(updt);
        }
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _PersonRepository.DeleteAsync(id);
        }
        private async Task<User> CreateUser(PersonDto input)
        {
            var user = ObjectMapper.Map<User>(input);
            ObjectMapper.Map(input, user);
            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));
            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
            }
            CurrentUnitOfWork.SaveChanges();
            return user;
        }
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}