namespace Facede;

public class Order{
    public int Id {get;set;}
    public String Item {get;set;}
    public int Qty {get;set;}
    public string ReceiverEmail {get;set;}
    public string Receiver {get;set;}

    public string ToString(){
        return $"Order details --  OrderId: {Id.ToString()}, Item: {Item}, Qty: {Qty}, Email: {ReceiverEmail}, Receiver: {Receiver}";
    }
}

//mock database
public class Database{

    private static List<Order> orders = new List<Order>{
        new (){ Id = 1, Item = "book", Qty = 5, ReceiverEmail = "abc@123.com", Receiver = "Tom"},
        new (){ Id = 2, Item = "pen", Qty = 10, ReceiverEmail = "pen@123.com", Receiver = ""},
        new (){ Id = 3, Item = "jacket", Qty = 2, ReceiverEmail = "jacket@123.com", Receiver = "Oliver"},
        new (){ Id = 4, Item = "soccer", Qty = -3, ReceiverEmail = "soccer@123.com", Receiver = "Ryan"},
        new (){ Id = 5, Item = "laptop", Qty = 1, ReceiverEmail = "abc123.com", Receiver = "Alice"},
    };
    
    public static Order Get(int Id){
        Console.WriteLine("Now calling database to fetch the order");
        Console.WriteLine($"Try to get order {Id} from database");
        return orders.FirstOrDefault(o=>o.Id == Id);
    }
}

//order validation system
public class OrderValidator{
    public static bool ValidateOrder(Order order){
        Console.WriteLine("Now calling validating system to validate the order");
        if(order == null){
            Console.WriteLine("Order doesn't exist");
            return false;
        }        

        Console.WriteLine(order.ToString());
        if(string.IsNullOrWhiteSpace(order.ReceiverEmail)){
            Console.WriteLine("Receiver email can't be null or empty");
            return false;
        }

        if(!order.ReceiverEmail.Contains("@")){
            Console.WriteLine("Invalid receiver email format");
            return false;
        }

        if(order.Qty <= 0){
            Console.WriteLine("Order must contain at least one item");
            return false;
        }

        if(string.IsNullOrWhiteSpace(order.Receiver)){
            Console.WriteLine("Receiver name can't be null or empty");
            return false;
        }

        return true;
    }
}

//order print system
public class Label{
    public static void PrintLabel(Order order){
        Console.WriteLine("Now calling printing system to generate label");
        Console.WriteLine($"Receiver: {order.Receiver}    Tracking: {new Random().NextInt64(50000000,90000000)} ");
    }
}

//facade interface api
public class PrintService{
    public void PrintOrder(int Id){
        Console.WriteLine("Now start print order process...");
        var order = Database.Get(Id);
        if(OrderValidator.ValidateOrder(order)){
            Label.PrintLabel(order);
        } 
        Console.WriteLine("------------------------------------------------------");
    }
}

public class Test{
    public static void TestFacade(){
        var printService = new PrintService();
        printService.PrintOrder(1);
        printService.PrintOrder(2);
        printService.PrintOrder(3);
        printService.PrintOrder(4);
        printService.PrintOrder(5);
        printService.PrintOrder(6);
    }
}
