namespace FactoryMethod;

public interface ILabel{
    void Print();
}

public class DHLLabel : ILabel{
    public void Print(){
        Console.WriteLine("Print DHL Label");
    }
}

public class TNTLabel : ILabel{
    public void Print(){
        Console.WriteLine("Print TNT Label");
    }
}

public class UPSLabel : ILabel{
    public void Print(){
        Console.WriteLine("Print UPS Label");
    }
}

public interface ILabelFactory{
    void Print();

}

public class DHL : ILabelFactory{
    public void Print(){
        new DHLLabel().Print();
    }
}

public class TNT : ILabelFactory{
    public void Print(){
        new TNTLabel().Print();
    }
}

public class UPS : ILabelFactory{
    public void Print(){
        new UPSLabel().Print();
    }
}

public class Test{
    public static void TestFactoryMethod(){
        ILabelFactory factory = new DHL();
        factory.Print();
        factory = new TNT();
        factory.Print();
        factory = new UPS();
        factory.Print();
    }
}
