
using ClaimAPI.Models;
using ClaimAPI.Repositories;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace ClaimAPI.Services
{
    public class PolicyConsumerService : BackgroundService
    {
        private IPolicyMongoRepo _policyMongoRepo;
        private IConfiguration _configuration;
        private string response;
        public PolicyConsumerService(IPolicyMongoRepo policyMongoRepo, IConfiguration configuration)
        {
                _configuration = configuration;
                _policyMongoRepo = policyMongoRepo;
        }    

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var BootstrapServer = _configuration["BootStrapServer"];
            var GroupId = _configuration["GroupId"];
            var TopicName = _configuration["TopicName"];
            return ConsumePolicyData(TopicName, GroupId, BootstrapServer);
            


        }

        public async Task<string> ConsumePolicyData(string TopicName,
           string Group_Id, string BootstarpServer)
        {

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = BootstarpServer,
                GroupId = Group_Id,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            using (var c = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
            {
                c.Subscribe(TopicName);

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(cts.Token);
                            Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                            response = $"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.";
                            var result = JsonConvert.DeserializeObject<List<Policy>>(cr.Value);
                            foreach (var policy in result)
                            {
                                policy.PolicyNo = policy.PolicyNo + new Random().Next(10000);
                                _policyMongoRepo.AddPolicy(policy);
                            }
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                            response = $"Error occured: {e.Error.Reason}";
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
                return response;

            }
        }

    }
}
