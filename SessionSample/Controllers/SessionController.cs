using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionSample.Models;

namespace SessionSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public SessionController()
        {

        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetSessionInfo() { 

            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUserName)))
            {
                return Unauthorized();
            }
            var username = HttpContext.Session.GetString(SessionVariables.SessionKeyUserName);
            var sessionId = HttpContext.Session.GetString(SessionVariables.SessionKeySessionId);

            List<string> sessionInfo = new List<string>();

            if (username != null && sessionId != null) {
                sessionInfo.Add(username);
                sessionInfo.Add(sessionId);
            }

            return sessionInfo;
        }

        [HttpPost]
        public ActionResult<IEnumerable<string>> PostSessionInfo([FromBody]UserInfo userInfo)
        {

            if (userInfo == null || userInfo.USER_ID == null || userInfo.USER_ID.Length == 0) { 
                throw new ArgumentNullException(nameof(userInfo));
            }

            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUserName)))
            {
                HttpContext.Session.SetString(SessionKeyEnum.SessionKeyUserName.ToString(), userInfo.USER_ID);
                HttpContext.Session.SetString(SessionKeyEnum.SessionKeySessionId.ToString(), Guid.NewGuid().ToString());
            }

            var username = HttpContext.Session.GetString(SessionVariables.SessionKeyUserName);
            var sessionId = HttpContext.Session.GetString(SessionVariables.SessionKeySessionId);
           
            List<string> sessionInfo = new List<string>();

            if (username != null && sessionId != null)
            {
                sessionInfo.Add(username);
                sessionInfo.Add(sessionId);
            }

            return sessionInfo;
        }
    }
}
