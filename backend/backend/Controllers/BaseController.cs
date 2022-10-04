using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    public class BaseController : ControllerBase
    {
        protected ActionResult<T> CreateOkResponse<T>(T payload)
        {
            return Ok(payload);
        }

        protected async Task<ActionResult<T>> HandleRequest<T>(Func<Task<T>> action) where T : class
        {
            try
            {
                T result = await action();
                return CreateOkResponse(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DuplicateException ex)
            {
                return Conflict(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (ServiceUnavailableException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }
    }
}
