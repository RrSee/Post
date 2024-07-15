namespace Post;
internal class Notification
{
    public int id { get; set; }
    public string text { get; set; }
    public DateTime dateTime { get; set; }
    public User fromUser { get; set; }

    public Notification(int id, string text, DateTime dateTime, User fromUser)
    {
        this.id = id;
        this.text = text;
        this.dateTime = dateTime;
        this.fromUser = fromUser;
    }

    public override string ToString()
    => $"Id:{id}\nText:{text}\nDateTime:{dateTime}\nFromUser:{fromUser}";
}

