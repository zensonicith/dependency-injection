using DI.Core;

var collection1 = new DiServiceCollection();

collection1.RegisterSingleton<RandomGuidProvider>();
collection1.RegisterTransient<RandomGuidProvider>();

var container1 = collection1.GenerateContainer();

var serviceFirst = container1.GetRequired<RandomGuidProvider>();
var serviceSecond = container1.GetRequired<RandomGuidProvider>();

System.Console.WriteLine(serviceFirst.RandomGuid);
System.Console.WriteLine(serviceSecond.RandomGuid);
System.Console.WriteLine(serviceFirst.RandomGuid == serviceSecond.RandomGuid);

// ===========================================================================

var collection2 = new DiServiceCollection();

collection2.RegisterSingleton<RandomGuidProvider>();

var container2 = collection2.GenerateContainer();

var serviceThird = container2.GetRequired<RandomGuidProvider>();
var serviceFourth = container2.GetRequired<RandomGuidProvider>();

System.Console.WriteLine(serviceThird.RandomGuid);
System.Console.WriteLine(serviceFourth.RandomGuid);
System.Console.WriteLine(serviceThird.RandomGuid == serviceFourth.RandomGuid);

// ===========================================================================

var collection = new DiServiceCollection();

collection.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
collection.RegisterTransient<ISomeService, SomeServiceOne>();

var container = collection.GenerateContainer();

var serviceOne = container.GetRequired<ISomeService>();
var serviceTwo = container.GetRequired<ISomeService>();

serviceOne.PrintSomething();
serviceTwo.PrintSomething();