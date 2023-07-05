using MISA.WebFresher2023.Demo.Common.Constant;
using MISA.WebFresher2023.Demo.Common.Resource;
using System.Net;

namespace MISA.WebFresher2023.Demo.Common.MyException
{
    /// <summary>
    /// Class Exception
    /// </summary>
    /// Author: LeDucTiep (23/05/2023)
    public class BadRequestException : BaseException
    {
        #region Field 
        /// <summary>
        /// Http code
        /// </summary>
        /// Author: LeDucTiep (09/06/2023)
        public readonly int StatusCode = (int)HttpStatusCode.BadRequest;
        #endregion

        #region Contructor
        public BadRequestException() : base()
        {
        }

        public BadRequestException(List<int> errorCode) : base(errorCode)
        {
            List<string> userMessage = base.UserMessage;
            List<string> devMessage = base.DevMessage;

            foreach (int code in errorCode)
            {
                switch (code)
                {
                    // Account
                    case (int)AnswerErrorCode.FullNameToLong:
                        userMessage.Add(AnswerUserMessage.FullNameToLong);
                        devMessage.Add(AnswerDevMessage.FullNameToLong);
                        break;
                    case (int)AnswerErrorCode.ContentToLong:
                        userMessage.Add(AnswerUserMessage.ContentToLong);
                        devMessage.Add(AnswerDevMessage.ContentToLong);
                        break;

                    case (int)RequestErrorCode.GuidInvalid:
                        userMessage.Add(RequestUserMessage.GuidInvalid);
                        devMessage.Add(RequestDevMessage.GuidInvalid);
                        break;
                }
            }

            ErrorCode = errorCode;
            UserMessage = userMessage;
            DevMessage = devMessage;
        }
        #endregion
    }
}
