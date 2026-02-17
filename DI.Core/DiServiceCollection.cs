namespace DI.Core
{
    public class DiServiceCollection
    {
        private List<ServiceDescriptor> _serviceDescriptor = [];

        public void RegisterSingleton<TService>()
        {
            _serviceDescriptor.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton));
        }

        public void RegisterTransient<TService>()
        {
            _serviceDescriptor.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));
        }

        public DiContainer GenerateContainer()
        {
            return new DiContainer(_serviceDescriptor);
        }
    }
}