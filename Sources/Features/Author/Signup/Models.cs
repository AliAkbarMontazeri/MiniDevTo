using FastEndpoints;

namespace Author.Signup;

public class Request
{
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class Validator : Validator<Request>
{
    // Insert rules here
    public Validator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Your first name is required.")
        .MinimumLength(3).WithMessage("Your first name must be at least 3 characters long.")
        .MaximumLength(25).WithMessage("Your first name is too long.");

        RuleFor(x => x.Email).NotEmpty().WithMessage("Your email is required.")
        .EmailAddress().WithMessage("A valid email is required.");

        RuleFor(x => x.Username).NotEmpty().WithMessage("A username is required.")
        .MinimumLength(3).WithMessage("Your username must be at least 3 characters long.")
        .MaximumLength(15).WithMessage("Your username is too long.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("A password is required.")
        .MinimumLength(10).WithMessage("Your password must be at least 6 characters long.")
        .MaximumLength(20).WithMessage("Your password is too long.");
    }
}

public class Response
{
    public string Message { get; set; } = null!;
}

