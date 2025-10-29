using Business.Interfaces;
using Entity.Dto.Default;
using Entity.Dto.Select;
using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class PersonController : BaseController<PersonDto,Person,PersonSelectDto>
    {
        public PersonController(IBaseBusiness<PersonDto, Person, PersonSelectDto> service) : base(service)
        {
        }
    }
}
