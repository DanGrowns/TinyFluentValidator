namespace TinyFluentValidator.Interfaces
{
    public interface IValidateWith<TProperty>
    {
        public TProperty Property { get; }
    }
}