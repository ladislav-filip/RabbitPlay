// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var sender = new Sender();

// for(var i=3000; i< 7000; i++)
// {
//     sender.Send(i);
//     sender.Send(i);
//     sender.Send(i);
//     //Task.Delay(200);
// }

sender.Delete(1001);

Console.WriteLine("Finnish.");