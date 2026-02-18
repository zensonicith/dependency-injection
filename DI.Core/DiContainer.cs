namespace DI.Core
{
    public class DiContainer(List<ServiceDescriptor> serviceDescriptors)
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors = serviceDescriptors;

        public object GetService(Type serviceType)
        {
            //* Tìm service đã đăng ký
            var descriptor = _serviceDescriptors
                .LastOrDefault(x =>
                    x.ServiceType == serviceType
                );

            if (descriptor == null)
            {
                throw new Exception($"Service of type {serviceType.Name} is not registered");
            }

            //* Nếu instance đã tồn tại (Singleton), trả về instance đó
            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Cannot instantiate abstract classes or interfaces");
            }

            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters()
                .Select(x => GetService(x.ParameterType))
                .ToArray();

            //* Nếu chưa có instance, tạo mới

            // var implementation = constructorInfo.Invoke(parameters);
            var implementation = Activator.CreateInstance(actualType, parameters)
                 ?? throw new Exception("System error.");

            //? Kiểm tra lifetime, nếu là singleton thì lưu instance lại để tái sử dụng
            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                descriptor.Implementation = implementation;
            }

            // Trả về instance 
            return implementation;
        }

        public T GetRequired<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}