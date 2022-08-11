namespace Template;

public class Order{
    public int Id {get;set;}
    public string City {get;set;}
    public string PostCode {get;set;}
    public string Receiver {get;set;}
    public string ReceiverEmail {get;set;}
    public string Item {get;set;}
}
public abstract class PrintLabel{
    private static int size = 70;
    private const string title = "Common Label";
    private static char style = '~';
    protected string border = "|";
    public virtual bool Validate(Order order){
        Console.WriteLine("General validation is starting...");
        Console.WriteLine("Validation is successful...");
        return true;
    }
    public virtual void GenerateLabel(Order order){
        Console.WriteLine("Common labels -> Start generating label...");
        var insert = new String(style, (size - title.Length)/2);
        Console.WriteLine("{0}{1}{2}", insert, title, insert);
        Console.WriteLine(GetLabelLine($"{border} Date: {DateTime.Now.ToShortDateString()}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Receiver: {order.Receiver}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Email   : {order.ReceiverEmail}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Item    : {order.Item}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Address : {order.City}-{order.PostCode}", size, border));
        Console.WriteLine(new String(style, size));
    }
    
    //very simple template just for demo
    public void Print(Order order){
        if(Validate(order)){
            GenerateLabel(order);
        }
        else{
            Console.WriteLine("Printing label failed due to validation failure");
        }
        
    }

    public string GetLabelLine(string input, int size, string symbol){
        return input + new String(' ', size - input.Length) + symbol;        
    }
}

public class DHL : PrintLabel{
    private static int size = 60;
    private const string title = "DHL Label";
    private static char style = '-';
    
    public override bool Validate(Order order)
    {
        var header = "DHL -> ";
        Console.WriteLine($"{header}Start validating...");
        if(string.IsNullOrWhiteSpace(order.ReceiverEmail)){
            Console.WriteLine("{0}Receiver email can't be empty", new String(' ',header.Length));
            return false;
        }
        return true;
    }

    public override void GenerateLabel(Order order)
    {
        Console.WriteLine("DHL -> Start generating label...");
        var insert = new String(style, (size - title.Length)/2);
        Console.WriteLine("{0} {1} {2}", insert, title, insert);
        Console.WriteLine(GetLabelLine($"{border} Email   : {order.ReceiverEmail}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Receiver: {order.Receiver}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Product    : {order.Item}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Location : {order.City}/{order.PostCode}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Date: {DateTime.Now.ToShortDateString()}", size, border));
        Console.WriteLine(new String(style, size));
    }
}

public class UPS : PrintLabel{
    public static int size = 50;
    private const string title = "UPS Label";
    private static char style = '*';
    public override bool Validate(Order order)
    {
        var header = "UPS -> ";
        Console.WriteLine($"{header}Start validating...");
        if(order.PostCode.Length > 4){
            Console.WriteLine("{0}Postcode is incorrect", new String(' ', header.Length));
            return false;
        }
        return true;
    }

    public override void GenerateLabel(Order order)
    {
        Console.WriteLine("UPS -> Start generating label...");
        var insert = new String(style, (size - title.Length)/2);
        Console.WriteLine("{0} {1} {2}", insert, title, insert);
        Console.WriteLine(GetLabelLine($"{border} Receiver: {order.Receiver}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Email   : {order.ReceiverEmail}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Product    : {order.Item}", size, border));
        Console.WriteLine(GetLabelLine($"{border} Location : {order.City}/{order.PostCode}", size, border));
        Console.WriteLine(new String(style, size));
    }
}

public class SELFSERVICE : PrintLabel{
    
    public override bool Validate(Order order)
    {
        return base.Validate(order);
    }

    public override void GenerateLabel(Order order)
    {
        base.GenerateLabel(order);
    }
}

public class Test{
    public static void TestTemplate(){
        var order = new Order{
            Id = 1,
            Item = "Rugby",
            City = "Auckland",
            PostCode = "1010",
            Receiver = "All Blacks",
            ReceiverEmail = "allblacks@allblacks.com"
        };
        PrintLabel label = new DHL();
        label.Print(order);
        label = new UPS();
        label.Print(order);
        label = new SELFSERVICE();
        label.Print(order);

        order.PostCode = "123456";
        order.ReceiverEmail = string.Empty;
        label = new DHL();
        label.Print(order);
        label = new UPS();
        label.Print(order);
        label = new SELFSERVICE();
        label.Print(order);
    }
}


