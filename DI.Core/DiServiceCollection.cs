namespace DI.Core
{
    public class DiServiceCollection
    {
        private readonly List<ServiceDescriptor> _serviceDescriptor = [];

        //* Đăng ký service Singleton lifetime
        public void RegisterSingleton<TService>()
        {
            _serviceDescriptor.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton));
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptor.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
        }

        //* Đăng ký service Transient lifetime
        public void RegisterTransient<TService>()
        {
            _serviceDescriptor.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptor.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }

        //* Tạo container từ danh sách service đã đăng ký
        public DiContainer GenerateContainer()
        {
            return new DiContainer(_serviceDescriptor);
        }
    }
}