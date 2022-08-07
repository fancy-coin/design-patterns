public interface ITravel{
    void Go();
}

public class Car : ITravel{
    public void Go(){
        Console.WriteLine("Travel by Car");
    }
}

public class Ship : ITravel{
    public void Go(){
        Console.WriteLine("Travel by Ship");
    }
}

public class Plane : ITravel{
    public void Go(){
        Console.WriteLine("Travel by Plane");
    }
}

public class Client{
    private ITravel travel;
    public Client(ITravel travel){
        this.travel = travel;
    }

    public void Travel(){
        travel.Go();
    }
}

public partial class Test{
    public static void TestStrategy(){
        Console.WriteLine("****** Start Strategy Test ******");
        var car = new Car();
        var client = new Client(car);
        client.Travel();
        var ship = new Ship();
        client = new Client(ship);
        client.Travel();
        var plane = new Plane();
        client = new Client(plane);
        client.Travel();
        Console.WriteLine();
    }
}

