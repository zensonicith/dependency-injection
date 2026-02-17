namespace DI.Core
{
    public class DiContainer(List<ServiceDescriptor> serviceDescriptors)
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors = serviceDescriptors;

        public T GetRequired<T>()
        {
            //* Tìm service đã đăng ký
            var descriptor = _serviceDescriptors
                .SingleOrDefault(x =>
                    x.ServiceType == typeof(T)
                );

            if (descriptor == null)
            {
                throw new Exception($"Service of type {typeof(T).Name} is not registered");
            }

            //* Nếu instance đã tồn tại (Singleton), trả về instance đó
            if (descriptor.Implementation != null)
            {
                return (T)descriptor.Implementation;
            }

            //* Nếu chưa có instance, tạo mới
            var implementation = (T)Activator.CreateInstance(descriptor.ServiceType);

            //? Kiểm tra lifetime, nếu là singleton thì lưu instance lại để tái sử dụng
            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                descriptor.Implementation = implementation;
            }

            // Trả về instance 
            return implementation;
        }
    }
}