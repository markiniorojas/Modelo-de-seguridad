using Business.Interfaces;
using Entity.Dto.Default;
using Entity.Dto.Select;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class FormController : BaseController<FormDto>
    {
        public FormController(IBaseBusiness<FormDto> service) : base(service)
        {
        }
    }
}
