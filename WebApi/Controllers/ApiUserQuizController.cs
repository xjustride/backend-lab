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

        [HttpPost]
        [Route("{quizId}/items/{itemId}/answers")]
        public ActionResult SaveAnswer(int quizId, int itemId, QuizItemUserAnswerDTO answer)
        {
            _userService.SaveUserAnswerForQuiz(quizId, 1, itemId, answer.Answer);
            return Ok();
        }

        [HttpGet]
        [Route("{quizId}/answers")]
        public ActionResult<object> CountCorrectAnswers(int quizId)
        {
            int count = _userService.CountCorrectAnswersForQuizFilledByUser(quizId, 1);
            return new
            {
                ValidAnswers = count,
                QuizId = quizId,
                UserId = 1
            };

        }

        // tworzenie quizow, zarzadzanie quizami i ich tworzenie apiadminquizcontroller/dodawaniequizu
        // dodawanie, usuwanie/
    }
}
