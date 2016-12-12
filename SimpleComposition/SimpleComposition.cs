using SimpleComposition.Abstracts;
using SimpleComposition.Core;
using SimpleComposition.Exceptions;
using System.Linq;
using System.Reflection;

namespace SimpleComposition
{
    public sealed class SimpleComposition
    {
        private static SimpleComposition _instance = new SimpleComposition();
        private ISimpleCompositionContainer _container;
        private bool _isBuilt = false;

        public static SimpleComposition Instance { get { return _instance; } }

        private void Verify()
        {
            if (!_isBuilt) throw new ContainerInitialiseException();
        }

        public ISimpleCompositionRegistration Register(params Assembly[] assemblies)
        {
            return new SimpleCompositionRegistration((container) =>
            {
                _container = container ?? new SimpleCompositionContainer();

                var componentTypes = assemblies.SelectMany(a =>
                    a.DefinedTypes.Where(t =>
                        t.ImplementedInterfaces.Any(i => i == typeof(ITransientComponent) || i == typeof(IPersitentComponent))
                    )
                );

                foreach (var type in componentTypes)
                {
                    var singleton = type.ImplementedInterfaces.Any(i => i == typeof(IPersitentComponent));
                    var contracts = type.ImplementedInterfaces.Where(i => i != typeof(ITransientComponent) && i != typeof(IPersitentComponent));
                    foreach (var contract in contracts)
                    {
                        _container.Register(contract, type.AsType(), singleton);
                    }
                }

                var entitiesTypes = assemblies.SelectMany(a =>
                    a.DefinedTypes.Where(t =>
                        t.ImplementedInterfaces.Any(i => i == typeof(IEntity))
                    )
                );

                foreach (var type in entitiesTypes)
                {
                    _container.Register(type.AsType());
                }

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
