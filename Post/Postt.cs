namespace Post;
internal class Postt
{

    public int Id { get; set; }
    public string content { get; set; }
    public DateTime CreationDateTime { get; set; }
    public int likeCount { get; set; }
    public int viewCount { get; set; }

    public Postt(int ıd, string content, DateTime creationDateTime, int likeCount, int viewCount)
    {
        Id = ıd;
        this.content = content;
        CreationDateTime = creationDateTime;
        this.likeCount = likeCount;
        this.viewCount = viewCount;
    }

    public override string ToString()
    => $"Id:{Id}\nContent:{content}\nCreationDateTime:{CreationDateTime}\nLikeCount:{likeCount}\nViewCount:{viewCount}";
}

