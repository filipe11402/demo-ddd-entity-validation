using demo_ddd_entity_validation.Entities;
using demo_ddd_entity_validation.Enums;
using demo_ddd_entity_validation.Repositories;
using demo_ddd_entity_validation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace demo_ddd_entity_validation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUser request)
        {
            (User? user, IEnumerable<string> errors) = Entities.User.Create(request.Email, request.Name, request.Age);

            if (errors.Any())
            {
                return StatusCode(StatusCodes.Status400BadRequest, errors);
            }

            string createUserResult = await _userRepository.Create(
                user!
                );

            if (createUserResult == nameof(CreateUserEnum.Created))
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status400BadRequest, new { Message = createUserResult });
        }
    }
}
