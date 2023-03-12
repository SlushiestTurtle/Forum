namespace Forum.Interface
{
    public interface ICommentService
    {
        Task Send(string from, string subject, string comments);
    }
}
