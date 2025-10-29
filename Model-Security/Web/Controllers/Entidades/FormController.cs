using Business.Interfaces;
using Business.Interfaces.Model_Security;
using Entity.Dto.Default;
using Entity.Dto.Select;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FormController : BaseController<Form, FormDto, FormSelectDto>
    {
        public FormController(IFormBusiness service)
            : base(service)
        {
        }
    }
}
