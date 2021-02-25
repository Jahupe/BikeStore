using AutoMapper;
using BikeStore.Api.Responses;
using BikeStore.Core.DTOs;
using BikeStore.Core.Entities;
using BikeStore.Core.Enumerations;
using BikeStore.Core.Interfaces;
using BikeStore.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BikeStore.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrador))]
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityservice;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public SecurityController(ISecurityService securityservice, IMapper mapper, IPasswordService passwordService)
        {
            _securityservice = securityservice;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SecurityDto securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);
            security.Password= _passwordService.Hash(security.Password);
            await _securityservice.RegisterUser(security);
            securityDto = _mapper.Map<SecurityDto>(security);
            var response = new ApiResponse<SecurityDto>(securityDto);
            return Ok(response);
        }
    }
}
