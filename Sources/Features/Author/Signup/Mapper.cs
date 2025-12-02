using System.Globalization;

namespace Author.Signup;

public class Mapper : Mapper<Request, Response, Dom.Author>
{
    static readonly CultureInfo _culture = new("en-US");

    public override Dom.Author ToEntity(Request req) => new()
    {
        FirstName = _culture.TextInfo.ToTitleCase(req.FirstName),
        LastName = _culture.TextInfo.ToTitleCase(req.LastName),
        Email = req.Email.ToLower(),
        Username = req.Username,
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
        SignedUpDate = DateOnly.FromDateTime(DateTime.UtcNow)
    };
}