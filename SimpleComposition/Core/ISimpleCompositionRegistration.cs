using System;

namespace SimpleComposition.Core
{
    public interface ISimpleCompositionRegistration
    {
        void Build(ISimpleCompositionContainer customContainer = null);
    }

    public class SimpleCompositionRegistration : ISimpleCompositionRegistration
    {
        private Action<ISimpleCompositionContainer> _customContainerRegistration;

        public SimpleCompositionRegistration(Action<ISimpleCompositionContainer> customerContainerRegistration)
        {
            _customContainerRegistration = customerContainerRegistration;
        }

        public void Build(ISimpleCompositionContainer customContainer = null)
        {
            _customContainerRegistration(customContainer);
        }
    }
}
