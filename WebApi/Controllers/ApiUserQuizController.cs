using ApplicationCore.Interfaces.UserService;
using ApplicationCore.Models.QuizAggregate;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/v1/user/quizzes")]
    public class ApiUserQuizController : ControllerBase
    {
        private IQuizUserService _userService;
       public ApiUserQuizController(IQuizUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDTO?> GetQuizById(int id) 
        {
            var result = (_userService.FindQuizById(id));
            if (result == null) 
            {
                return NotFound();  
            }
            return QuizDTO.Of(result);
        }
    }
}
