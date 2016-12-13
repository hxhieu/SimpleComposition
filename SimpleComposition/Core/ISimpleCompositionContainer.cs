using DryIoc;
using System;

namespace SimpleComposition.Core
{
    public interface ISimpleCompositionContainer : IDisposable
    {
        void Register(Type contract, Type service, bool singleton = false);
        void Register(Type service, bool singleton = false);
        TService Resolve<TService>();
    }

    /// <summary>
    /// Default container using DryIoC at the back
    /// </summary>
    public class SimpleCompositionContainer : ISimpleCompositionContainer
    {
        public bool IsDisposed { get; set; }
        private IContainer _container = new Container(rules => rules.WithoutThrowOnRegisteringDisposableTransient());

        public void Dispose()
        {
            if (!IsDisposed)
            {
                _container.Dispose();
                IsDisposed = true;
            }
        }

        public void Register(Type service, bool singleton = false)
        {
            if (_container.IsRegistered(service)) return;

            _container.Register(service, singleton ? Reuse.Singleton : Reuse.Transient);
        }

        public void Register(Type contract, Type service, bool singleton = false)
        {
            if (_container.IsRegistered(contract)) return;

            _container.Register(contract, service, singleton ? Reuse.Singleton : Reuse.Transient);
        }

        public TService Resolve<TService>()
        {
            var service = _container.Resolve<TService>();
            _container.InjectPropertiesAndFields(service, PropertiesAndFields.Auto);
            return service;
        }
    }
}
