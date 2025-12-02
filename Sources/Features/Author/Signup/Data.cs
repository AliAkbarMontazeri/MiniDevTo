using MongoDB.Entities;

namespace Author.Signup;

public static class Data
{
    internal static Task<bool> IsEmailAddressTaken(string email) => DB.Find<Dom.Author>()
        .Match(a => a.Email == email)
        .ExecuteAnyAsync();

    internal static Task<bool> IsUsernameTaken(string lowerCaseUsername) => DB.Find<Dom.Author>()
        .Match(a => a.Username.ToLower() == lowerCaseUsername)
        .ExecuteAnyAsync();

    internal static Task CreateNewAuthor(Dom.Author author) => author.SaveAsync();
}
