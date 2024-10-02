using System;
using System.Collections.Generic;

namespace DI
{
    public class DIContainer
    {
        private readonly DIContainer _parentContainer;
        private readonly Dictionary<(string, Type), DIRegistration> _registrations = new();
        private readonly HashSet<(string,Type)> _resolutions = new();
        public DIContainer(DIContainer parentContainer)
        {
            _parentContainer = parentContainer;
        }

        public void SingletonRegistration<T>(Func<DIContainer, T> factory)
        {
            SingletonRegistration(null, factory);
        }

        public void SingletonRegistration<T>(string tag, Func<DIContainer, T> factory)
        {
            var key = (tag, typeof(T));
            Registration(key, factory, true);
        }

        public void TransientRegistration<T>(Func<DIContainer, T> factory)
        {
            TransientRegistration(null, factory);
        }

        public void TransientRegistration<T>(string tag, Func<DIContainer, T> factory)
        {
            var key = (tag, typeof(T));
            Registration(key, factory, false);
        }

        public void InstanceRegistration<T>(T instance)
        {
            InstanceRegistration(null, instance);
        }

        public void InstanceRegistration<T>(string tag, T instance)
        {
            var key = (tag, typeof(T));

            if (_registrations.ContainsKey(key))
            {
                throw new Exception();
            }

            _registrations[key] = new DIRegistration
            {
                Instance = instance,
                IsSingleton = true
            };
        }

        public T Resolve<T>(string tag = null)
        {
            var key = (tag, typeof(T));

            if(_resolutions.Contains(key))
            {
                throw new Exception();
            }

            _resolutions.Add(key);

            try
            {
                if (_registrations.TryGetValue(key, out var registration))
                {
                    if (registration.IsSingleton)
                    {
                        if (registration.Instance == null && registration.Factory != null)
                        {
                            registration.Instance = registration.Factory(this);
                        }

                        return (T)registration.Instance;
                    }
                    return (T)registration.Factory(this);
                }

                if (_parentContainer != null)
                {
                    return _parentContainer.Resolve<T>();
                }
            }
            finally
            {
                _resolutions.Remove(key);   
            }


            throw new Exception();
        }

        private void Registration<T>((string, Type) key, Func<DIContainer, T> factory, bool isSingleton)
        {
            if (_registrations.ContainsKey(key))
            {
                throw new Exception();
            }

            _registrations[key] = new DIRegistration
            {
                Factory = f => factory,
                IsSingleton = isSingleton
            };
        }

    }
}

