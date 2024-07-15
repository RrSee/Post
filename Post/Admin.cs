using System.Xml.Linq;

namespace Post;
internal class Admin
{

    public int id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public List<Postt> posts { get; set; }
    public List<Notification> Notifications { get; set; }

    public Admin(int id, string username, string email, string password, List<Postt> posts, List<Notification> notifications)
    {
        this.id = id;
        this.username = username;
        this.email = email;
        this.password = password;
        this.posts = posts;
        Notifications = notifications;
    }

    public override string ToString()
    => $"Id:{id}\nUsername:{username}\nEmail:{email}\nPassword:{password}\nPost:{posts}\nNotification:{Notifications}";
}

