namespace Proxy;

public interface ILogin{
    public void Login();
}
public class UserLogin : ILogin{
    public string Name {get;set;}
    public string UserIP {get;set;}
    public void Login(){
        Console.WriteLine($"Your IP: {UserIP}");
        Console.WriteLine($"Welcome to ABC eCommerce, {Name}");
    }
}

public class Proxy : ILogin{
    private UserLogin user;
    private static List<string> whitelist = new (){
        "1.1.1.1",
        "202.303.404.505"
    };
    public Proxy(UserLogin user){
        this.user = user;
    }
    public void Login(){
        if(!whitelist.Contains(user.UserIP)){
            Console.WriteLine($"Your IP: {user.UserIP}");
            Console.WriteLine($"Sorry {user.Name}, you don't have permission to access ABC eCommerce");
            Console.WriteLine();
            return;
        }
        user.Login();
    }
}

public class Test{
    public static void TestProxy(){
        UserLogin user = new (){ Name = "Robert Smith", UserIP = "2.3.4.5"};
        var proxy = new Proxy(user);
        proxy.Login();
        Console.WriteLine("Now user change their ip address...");
        user.UserIP = "1.1.1.1";
        proxy.Login();
    }
}