namespace DI.Core
{
    public class RandomGuidProvider : IRandomGuidProvider
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}