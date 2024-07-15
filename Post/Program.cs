using Post;

int sec;
int t = 0;
int k = 0;
int id;

string content;
DateTime CreationDateTime;
const int likeCount = 0;
const int viewCount = 0;
;
List<User> users = new List<User>();
List<Admin> admins = new List<Admin>();
List<Postt> post1 = new List<Postt>();
List<Postt> allPost = new List<Postt>();
List<Notification> notifications = new List<Notification>();

void chooseUser()
{
    Console.WriteLine("Admin or User: 1-Admin 2- User");
    Console.Write("Secim: ");
    sec = Convert.ToInt32(Console.ReadLine());
    sert(sec);
}

void sert(int id)
{
    if (id == 1)
    {
        Console.WriteLine("Admin-e Giris Olunur...");
        var (email, password) = signText();
        adminCheck(email, password, admins);
        if (t == 1)
        {
            foreach (Admin admin in admins)
            {
                if (admin.email == email)
                {
                    showAdmin(admin);
                }
            }
        }
        else
        {
            throw new PassException("Yanlis Secim!");
        }
    }
    else if (id == 2)
    {
        Console.WriteLine("User-e Giris Olunur...");
        var (email, password) = signText();
        userCheck(email, password, users);
        if (t == 1)
        {
            foreach (User user in users)
            {
                if (user.email == email)
                {
                    showUser(user);
                }
            }
        }
        else
        {
            throw new PassException("Yanlis Secim!");
        }
    }

    else
    {
        throw new PassException("Yanlis Id!");
    }
}

(string, string) signText()
{
    Console.Write("Email Daxil Edin: ");
    string email = Console.ReadLine();
    Console.Write("Password Daxil Edin: ");
    string password = Console.ReadLine();
    return (email, password);
}

User userCheck(string email, string pass, List<User> users)
{
    t = 0;
    foreach (User user in users)
    {
        if (email == user.email && pass == user.password)
        {
            Console.WriteLine("Giris Olundu!");
            t++;
            return user;
        }
    }
    throw new PassException("Yanlis Email Ve Ya Password!");
    return null;
}

Admin adminCheck(string email, string pass, List<Admin> ads)
{
    t = 0;
    foreach (Admin admin in ads)
    {
        if (email == admin.email && pass == admin.password)
        {
            Console.WriteLine("Giris Olundu!");
            t++;
            return admin;
        }
    }
    throw new PassException("Yanlis Email Ve Ya Password!");
    return null;
}

void showAdmin(Admin admin)
{
    Console.WriteLine("1-Notifications");
    Console.WriteLine("2-Add Post");
    Console.Write("Secim: ");
    sec = Convert.ToInt32(Console.ReadLine());
    if (sec == 1)
    {
        foreach (Notification not in adminCheck(admin.email, admin.password, admins).Notifications)
        {
            Console.WriteLine(not);
        }
    }
    else if (sec == 2)
    {

        Console.Write("Id: ");
        id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Content: ");
        content = Console.ReadLine();
        CreationDateTime = DateTime.Now;
        allPost.Add(new Postt(id, content, CreationDateTime, likeCount, viewCount));
    }
    else
    {
        throw new PassException("Yanlis Secim!");
    }
}

void showUser(User userr)
{
    foreach (Postt post in allPost)
    {
        Console.WriteLine(post.Id);
    }
    Console.Write("Choose View Post: ");
    id = Convert.ToInt32(Console.ReadLine());
    foreach (Postt post in allPost)
    {
        if (post.Id == id)
        {
            Console.WriteLine(post);
            foreach (Admin ad in admins)
            {
                if (post.Id == ad.id)
                {
                    ad.Notifications.Add(new Notification(ad.id, "View", DateTime.Now, userr));
                    Console.WriteLine("1-Like 2-Geri");
                    Console.Write("Secim: ");
                    sec = Convert.ToInt32(Console.ReadLine());
                    if (sec == 1)
                    {
                        if (post.Id == ad.id)
                        {
                            ad.Notifications.Add(new Notification(k, "Like", DateTime.Now, userr));
                        }
                    }
                    else if (sec == 2)
                    {
                        foreach (Postt postt in allPost)
                        {
                            Console.WriteLine(postt.Id);
                        }
                    }
                    else
                    {
                        throw new PassException("Yanlis Secim!");
                    }
                }
                else
                {
                    throw new PassException("Yanlis Id!");
                }
            }
        }
        else
        {
            throw new PassException("Yanlis Id!");
        }
    }
    k++;
}



Admin admin1 = new Admin(1, "Revan", "revan.agazade.329@mail.ru", "123456789", post1, notifications);
User user1 = new User(1, "Revan", "Agazade", 20, "revan.agazade.329@mail.ru", "123456789");
users.Add(user1);
admins.Add(admin1);




try
{
    chooseUser();
}
catch (PassException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

