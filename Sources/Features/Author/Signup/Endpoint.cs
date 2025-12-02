namespace Author.Signup;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("api/author/signup");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var author = Map.ToEntity(req);

        // Handle email taken
        var emailIsTaken = await Data.IsEmailAddressTaken(author.Email);
        if (emailIsTaken)
            AddError(req => req.Email, "Email is already in use!");

        // Handle username taken
        var usernameIsTaken = await Data.IsUsernameTaken(author.Username.ToLower());
        if (usernameIsTaken)
            AddError(req => req.Username, "Username is already taken!");

        // Throw any errors encountered during signup process
        ThrowIfAnyErrors();

        // Create new author in the database
        await Data.CreateNewAuthor(author);

        // Send ok response
        await Send.OkAsync(new() { Message = "Signed up successfully" });
    }
}