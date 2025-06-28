namespace AvansDevops.ProjectManagement.Forum;

public class Message {
    public string Content { get; set; }
    public User Author { get; set; }
    public DateTime Timestamp { get; set; }

    public Message(string content, User author) {
        Content = content;
        Author = author;
        Timestamp = DateTime.Now;
    }

    public override string ToString() {
        return $"{Timestamp} - {Author.Name}: {Content}";
    }
}