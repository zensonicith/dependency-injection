using DI.Core;

var collection1 = new DiServiceCollection();

collection1.RegisterSingleton<RandomGuidGenerator>();

var container1 = collection1.GenerateContainer();

var serviceFirst = container1.GetRequired<RandomGuidGenerator>();
var serviceSecond = container1.GetRequired<RandomGuidGenerator>();

System.Console.WriteLine(serviceFirst.RandomGuid);
System.Console.WriteLine(serviceSecond.RandomGuid);
System.Console.WriteLine(serviceFirst.RandomGuid == serviceSecond.RandomGuid);

// ===========================================================================

var collection2 = new DiServiceCollection();

collection2.RegisterTransient<RandomGuidGenerator>();

var container2 = collection2.GenerateContainer();

var serviceThird = container2.GetRequired<RandomGuidGenerator>();
var serviceFourth = container2.GetRequired<RandomGuidGenerator>();

System.Console.WriteLine(serviceThird.RandomGuid);
System.Console.WriteLine(serviceFourth.RandomGuid);
System.Console.WriteLine(serviceThird.RandomGuid == serviceFourth.RandomGuid);