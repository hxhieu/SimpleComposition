using DryIoc;
using System;

namespace SimpleComposition.Core
{
    public interface ISimpleCompositionContainer
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
        private static Container _container = new Container();

        public void Register(Type service, bool singleton = false)
        {
            _container.Register(service, singleton ? Reuse.Singleton : Reuse.Transient);
        }

        public void Register(Type contract, Type service, bool singleton = false)
        {
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
