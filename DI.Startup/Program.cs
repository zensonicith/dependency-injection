using DI.Core;

var services = new DiServiceCollection();

services.RegisterSingleton<RandomGuidGenerator>();
services.RegisterTransient<RandomGuidGenerator>();

var container = services.GenerateContainer();

var serviceFirst = container.GetService<RandomGuidGenerator>();
var serviceSecond = container.GetService<RandomGuidGenerator>();

System.Console.WriteLine(serviceFirst.RandomGuid);
System.Console.WriteLine(serviceSecond.RandomGuid);