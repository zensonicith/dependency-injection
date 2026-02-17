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

        //* Đăng ký service Transient lifetime
        public void RegisterTransient<TService>()
        {
            _serviceDescriptor.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));
        }

        //* Tạo container từ danh sách service đã đăng ký
        public DiContainer GenerateContainer()
        {
            return new DiContainer(_serviceDescriptor);
        }
    }
}