namespace AbstractFactory;

public interface ILabel{
    void Print();
}

public class DHLA4Label : ILabel{
    public void Print(){
        Console.WriteLine("Print DHL A4 label");
    }
}

public class DHLThermalLabel : ILabel{
    public void Print(){
        Console.WriteLine("Print DHL Thermal label");
    }
}

public class UPSA4Label : ILabel{
    public void Print(){
        Console.WriteLine("Print UPS A4 label");
    }
}

public class UPSThermalLabel : ILabel{
    public void Print(){
        Console.WriteLine("Print UPS Thermal label");
    }
}

public interface IFactory{
    ILabel GetA4Label();
    ILabel GetThermalLabel();
}

public class DHL : IFactory{
    public ILabel GetA4Label(){
        return new DHLA4Label();
    }
    public ILabel GetThermalLabel(){
        return new DHLThermalLabel();
    }
}

public class UPS : IFactory{
    public ILabel GetA4Label(){
        return new UPSA4Label();
    }
    public ILabel GetThermalLabel(){
        return new UPSThermalLabel();
    }
}

public class Test{
    public static void TestAbstractFactory(){
        IFactory factory = new DHL();
        ILabel label = factory.GetA4Label();
        label.Print();
        label = factory.GetThermalLabel();
        label.Print();

        factory = new UPS();
        label = factory.GetA4Label();
        label.Print();
        label = factory.GetThermalLabel();
        label.Print();
    }
}