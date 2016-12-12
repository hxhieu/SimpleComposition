namespace SimpleComposition.Attributes
{
    public class SimpleComponentAttribute
    {
        public bool IsSingleton { get; set; }
        public SimpleComponentAttribute(bool isSingleton = false)
        {
            IsSingleton = isSingleton;
        }
    }
}
