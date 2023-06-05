﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Services.AddressService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListAbpApp.Services.PersonService.Dtos
{
    [AutoMap(typeof(Person))]
    public class PersonDto : EntityDto<Guid>
    {
        /// <summary>
        ///
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        ///
        /// </summary>
        public long userId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public AddressDto Address { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string[] RoleNames { get; set; }
    }
}
