using RabbitMQ.Client;
using System;
using System.Text;

namespace ProjectIntegrationRabbit
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "saudacao_1",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                string message = "RabbitMQ";

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "saudacao_1",
                    basicProperties: null,
                    body: body);

                Console.WriteLine($" [x] Enviada : {message}");
            }
            Console.ReadLine();
        }
    }
}
