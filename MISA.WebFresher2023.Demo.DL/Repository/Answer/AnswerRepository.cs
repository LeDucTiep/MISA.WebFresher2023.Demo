using Microsoft.Extensions.Configuration;
using MISA.WebFresher2023.Demo.DL.Entity;

namespace MISA.WebFresher2023.Demo.DL.Repository
{
    public class AnswerRepository: BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(IConfiguration configuration) : base(configuration)
        {
        }

    }
}
