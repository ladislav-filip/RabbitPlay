// See https://aka.ms/new-console-template for more information

using Receive;

var receiver = new Receiver();

while (true)
{
    receiver.Consume(100);
    Task.Delay(2000);
}


Console.WriteLine("Finnish.");