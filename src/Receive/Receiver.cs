using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Receive;

public class Receiver
{
    public void Consume(int queueNr)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            var consumer = new EventingBasicConsumer(channel);

            //while (true)
            {
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($" [{DateTime.Now}] Received {0}", message);
                };
                channel.BasicConsume(queue: $"hello-{queueNr}",
                    autoAck: true,
                    consumer: consumer);
                

            }
        }
    }
}