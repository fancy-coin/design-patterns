namespace Flyweight;

public enum PrintType{
    Label,
    Invoice,
    Packslip
}

public class Printable{
    protected string Size {get;set;}
    protected string Type {get;set;}  
}

public class Label : Printable{
    public Label(){
        Size = "A4";
        Type = "LABEL";
        Console.WriteLine("Create label base for the first time");        
    }
}

public class Invoice : Printable{
    public Invoice(){
        Size = "A5";
        Type = "INVOICE";
        Console.WriteLine("Create invoice base for the first time");
    }
}

public class Packslip : Printable{
    public Packslip(){
        Size = "A3";
        Type = "PACKSLIP";
        Console.WriteLine("Create packslip base for the first time");
    }
}

public class DHLLabel{
    private Printable label;
    public string LabelContent {get;set;}
    public static int Times;
    public DHLLabel(){
        label = Factory.Get(PrintType.Label);
        LabelContent = "This is DHL label"; 
        Console.WriteLine($"DHL label has been printed {++Times} times");
    }
}

public class UPSLabel{
    private Printable label;
    public string LabelContent {get;set;}
    public static int Times;
    public UPSLabel(){
        label = Factory.Get(PrintType.Label);
        LabelContent = "This is UPS label"; 
        Console.WriteLine($"UPS label has been printed {++Times} times");
    }
}

public class DHLInvoice{
    private Printable invoice;
    public string InvoiceContent {get;set;}
    public static int Times;
    public DHLInvoice(){
        invoice = Factory.Get(PrintType.Invoice);
        InvoiceContent = "This is DHL invoice"; 
        Console.WriteLine($"DHL invoice has been printed {++Times} times");
    }
}

public class UPSInvoice{
    private Printable invoice;
    public string InvoiceContent {get;set;}
    public static int Times;
    public UPSInvoice(){
        invoice = Factory.Get(PrintType.Invoice);
        InvoiceContent = "This is UPS invoice"; 
        Console.WriteLine($"UPS invoice has been printed {++Times} times");
    }

}

public class DHLPackslip{
    private Printable packslip;
    public string PackslipContent {get;set;}
    public static int Times;
    public DHLPackslip(){
        packslip = Factory.Get(PrintType.Packslip);
        PackslipContent = "This is DHL packslip"; 
        Console.WriteLine($"DHL Packslip has been printed {++Times} times");
    }
}

public class UPSPackslip{
    private Printable packslip;
    public string PackslipContent {get;set;}
    public static int Times;
    public UPSPackslip(){
        packslip = Factory.Get(PrintType.Packslip);
        PackslipContent = "This is UPS packslip"; 
        Console.WriteLine($"UPS Packslip has been printed {++Times} times");
    }
}

public class Factory{
    private static Dictionary<PrintType, Printable> dic = new Dictionary<PrintType, Printable>();
    public static Printable Get(PrintType type){
        if(!dic.Keys.Contains(type)){
            Printable printable = type switch{
                        PrintType.Label => new Label(),
                        PrintType.Invoice => new Invoice(),
                        PrintType.Packslip => new Packslip(),
                        _ => new Label()
                    };
            dic.Add(type, printable);
        }
        return dic[type];        
    }
}

public class Test{
    public static void TestFlyweight(){
        new DHLLabel();
        new DHLLabel();
        new DHLLabel();
        new DHLInvoice();
        new DHLInvoice();
        new UPSLabel();
        new UPSInvoice();
        new UPSInvoice();
        new UPSInvoice();
        new UPSPackslip();
        new UPSPackslip();        
    }
}
