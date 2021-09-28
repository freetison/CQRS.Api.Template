namespace Domain.Model.Settings.EnvironmentSettings
{
    public class ServiceBus
    {
        public string ConnectionStrings { get; set; }
        public string QueueName { get; set; }
        public string TopicName { get; set; }
        public string SubscriptionName { get; set; }
    }
}
