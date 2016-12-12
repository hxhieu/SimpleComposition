using SimpleComposition.Abstracts;
using SimpleComposition.Core;
using SimpleComposition.Exceptions;
using System;
using System.Reflection;

namespace SimpleComposition
{
    public sealed class SimpleComposition
    {
        private static Lazy<SimpleComposition> _instance = new Lazy<SimpleComposition>();
        private static ISimpleCompositionContainer _container;
        private bool _isBuilt = false;

        public static SimpleComposition Instance { get { return _instance.Value; } }

        private void Verify()
        {
            if (!_isBuilt) throw new ContainerInitialiseException();
        }

        public ISimpleCompositionRegistration Register(params Assembly[] assemblies)
        {
            return new SimpleCompositionRegistration((container) =>
            {
                _container = container ?? new SimpleCompositionContainer();

                _isBuilt = true;
            });
        }

        public TEntity Create<TEntity>() where TEntity : IEntity
        {
            Verify();
            return _container.Resolve<TEntity>();
        }
    }
}
