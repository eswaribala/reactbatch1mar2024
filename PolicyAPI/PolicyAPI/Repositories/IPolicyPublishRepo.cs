namespace PolicyAPI.Repositories
{
    public interface IPolicyPublishRepo
    {
        Task<string> PublishMessage(string TopicName, string Message, 
            IConfiguration configuration);

    }
}
