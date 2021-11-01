# TinyFluentValidator

Conceptually similar to the FluentValidation package, with an a different approach which is designed to place the validations behind an always valid domain boundary.

### Get Started

Encapsulate a class so it is guarded from accidental changes in code, with a view to it only being changable on construction or by your ORM.

Errors are returned as a simple read only collection of strings with a default error message provided for each validation - errors can be overridden.

### Example
```csharp
using TinyFluentValidator;

public class Customer : IValidationEntity<Customer> {
    // Constructor that can be accessed by your ORM
    protected internal Customer() {}

    // Constructor that can be accessed from your code
    public Customer(int id, string forename, string surname) 
    {
        Id = id;
        Forename = forename;
        Surname = surname;
    } 

    public int Id { get; protected internal set; }
    public string Forename { get; protected internal set; }
    public string Surname { get; protected internal set; }

    public IReadOnlyList<string> StateIsValid(IValidator<Customer> validator) 
        => validator.Start(this)
                .RuleFor(x => x.Id).GreaterThan(0)
                .RuleFor(x => x.Forename).NotEmpty()
                .RuleFor(x => x.Surname).NotEmpty("Custom error message")
                .ToList();
}
```