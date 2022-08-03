
namespace FinalProject.Application.Wrappers.Queries
{
    public class BasePagingRequest
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 8;
    }
}
