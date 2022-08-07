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
    public ILabel PrintLabel(string type){
        ILabel label = type switch{
            "dhl" => new DHL(),
            "tnt" => new TNT(),
            "ups" => new UPS(),
            _ => new PlainLabel()
        };
        return label;
    }
}

public partial class Test{
    public static void TestSimpleFactory(){
        Console.WriteLine("****** Start Simple Factory Test ******");
        var factory = new Factory();
        factory.PrintLabel("dhl").Print();
        factory.PrintLabel("ups").Print();
        factory.PrintLabel("tnt").Print();
        factory.PrintLabel("jppost").Print();
        Console.WriteLine();
    }
}

