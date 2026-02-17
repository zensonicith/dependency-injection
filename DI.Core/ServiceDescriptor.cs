namespace DI.Core
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; } //* Xác định service
        public object Implementation { get; internal set; } //* Instance hiện tại (cho Singleton)
        public ServiceLifetime Lifetime { get; } //* Lifetime cho service

        //* Đăng ký service với instance đã tạo => Singleton
        public ServiceDescriptor(object implementation, ServiceLifetime lifetime)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;
            Lifetime = lifetime;
        }

        //* Đăng ký service nhưng chưa tạo instance, container tạo instance => Chọn lifetime
        public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
        }
    }
}