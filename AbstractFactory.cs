namespace AbstractFactory;

public interface ILabel{
    void Print();
}

public interface IThermalLabel{
    void Print();
}

public class DHLA4Label : ILabel{
    public void Print(){
        Console.WriteLine("Print DHL A4 label");
    }
}

public class DHLThermalLabel : IThermalLabel{
    public void Print(){
        Console.WriteLine("Print DHL Thermal label");
    }
}

public class UPSA4Label : ILabel{
    public void Print(){
        Console.WriteLine("Print UPS A4 label");
    }
}

public class UPSThermalLabel : IThermalLabel{
    public void Print(){
        Console.WriteLine("Print UPS Thermal label");
    }
}

public interface IFactory{
    ILabel GetA4Label();
    IThermalLabel GetThermalLabel();
}

public class DHL : IFactory{
    public ILabel GetA4Label(){
        return new DHLA4Label();
    }
    public IThermalLabel GetThermalLabel(){
        return new DHLThermalLabel();
    }
}

public class UPS : IFactory{
    public ILabel GetA4Label(){
        return new UPSA4Label();
    }
    public IThermalLabel GetThermalLabel(){
        return new UPSThermalLabel();
    }
}

public class Test{
    public static void TestAbstractFactory(){
        IFactory factory = new DHL();
        ILabel label = factory.GetA4Label();
        label.Print();
        IThermalLabel tlabel = factory.GetThermalLabel();
        tlabel.Print();

        factory = new UPS();
        label = factory.GetA4Label();
        label.Print();
        tlabel = factory.GetThermalLabel();
        tlabel.Print();
    }
}