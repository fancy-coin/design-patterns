namespace SimpleFactory;

public interface ILabel{
    public void Print();
}

public class DHL : ILabel{
    public void Print(){
        Console.WriteLine("Print DHL Label");
    }
}

public class TNT : ILabel{
    public void Print(){
        Console.WriteLine("Print TNT Label");
    }
}

public class UPS : ILabel{
    public void Print(){
        Console.WriteLine("Print UPS Label");
    }
}

public class PlainLabel : ILabel{
    public void Print(){
        Console.WriteLine("Sorry, no such carrier. Print Plain Label");
    }
}
public class Factory{
    public ILabel Get(string type){
        ILabel label = type switch{
            "dhl" => new DHL(),
            "tnt" => new TNT(),
            "ups" => new UPS(),
            _ => new PlainLabel()
        };
        return label;
    }
}

public class Test{
    public static void TestSimpleFactory(){
        var factory = new Factory();
        factory.Get("dhl").Print();
        factory.Get("ups").Print();
        factory.Get("tnt").Print();
        factory.Get("jppost").Print();
    }
}

