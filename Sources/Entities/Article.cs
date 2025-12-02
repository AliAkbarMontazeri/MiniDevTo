namespace Dom;

public class Article : Entity
{
    [ObjectId] // Indicate that this is a foreign key reference
    public string AuthorId { get; set; } = null!;
    public string AuthorName { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedOn { get; set; }
    public bool IsApproved { get; set; }
    [IgnoreDefault]
    public string? RejectionReason { get; set; }
    [IgnoreDefault]
    public Comment[] comments { get; set; } = Array.Empty<Comment>();

    public class Comment
    {
        [ObjectId]
        public string ID { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime DateAdded { get; set; }
    }
}
