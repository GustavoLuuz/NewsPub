using NewsPub.Domain;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace NewsPub.Services
{
    public class Mensageria : IMensageria
    {

        public void Configuration(Solicitation solicitation)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "solicitation_1",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(solicitation);
                var body = Encoding.UTF8.GetBytes(message);
                
                channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "solicitation_1",
                                 basicProperties: null,
                                 body: body);
            }
        }
    }
}
