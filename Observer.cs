namespace Oberser;

public interface IReceiver{
    public void Receive(string message);
}

public class Email : IReceiver{
    private string email => "notify@email.com";
    public void Receive(string message){
        Console.WriteLine($"Email:{email} get notified: {message}");
    }
}

public class Mobile : IReceiver{
    private string mobile => "0222233344";
    public void Receive(string message){
        Console.WriteLine($"Mobilephone:{mobile} get notified: {message}");
    }
}


public class PrintLabel{
    private List<IReceiver> receivers = new List<IReceiver>();
    public void Register(IReceiver receiver){
        receivers.Add(receiver);
    }

    public void Print(string orderNumber){
        Console.WriteLine($"Now print order : {orderNumber}");
        Notify($"order-{orderNumber} is printed");
    }
    private void Notify(string message){
        if(receivers.Any()){
            receivers.ForEach(r => r.Receive(message));
        }
    }
}

public class Test{
    public static void TestObserver(){
        var email = new Email();
        var mobile = new Mobile();
        var label = new PrintLabel();
        label.Register(email);
        label.Register(mobile);
        label.Print("Order-001");
        label.Print("Order-111");
    }
}