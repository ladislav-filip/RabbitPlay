using System.Text;
using RabbitMQ.Client;
using Send;

public class Sender {

    public void Send(int queueNr) {

        var factory = new ConnectionFactory() { HostName = "localhost" };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: $"hello-{queueNr}",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);                      

            string message = Helper.GenerateName(8);
            var body = Encoding.UTF8.GetBytes(message);

            var props = channel.CreateBasicProperties();
            // props.Persistent = true; // or props.DeliveryMode = 2;
            props.DeliveryMode = 2;
            
            channel.BasicPublish(exchange: "",
                                 routingKey: $"hello-{queueNr}",
                                 basicProperties: props,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        // Console.WriteLine(" Press [enter] to exit.");
        // Console.ReadLine();

    }

    public void Delete(int queueNr)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDelete($"hello-{queueNr}", ifEmpty: true);
    }

}