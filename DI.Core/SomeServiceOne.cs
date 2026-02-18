namespace DI.Core
{
    public class SomeServiceOne : ISomeService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;

        public SomeServiceOne(IRandomGuidProvider randomGuidProvider)
        {
            _randomGuidProvider = randomGuidProvider;
        }
        public void PrintSomething()
        {
            System.Console.WriteLine(_randomGuidProvider.RandomGuid);
        }
    }
}