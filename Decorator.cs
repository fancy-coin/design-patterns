using Builder;
namespace Decorator;

public enum Type{
    DHL,
    UPS
}

public interface IPrint{
    void Print();
}

public class LabelBase : IPrint{
    private string labelContent;
    public LabelBase(Address address, Contact contact, Product product){
        labelContent = $@"{address.ToString()}{Environment.NewLine}{contact.ToString()}{Environment.NewLine}{product.ToString()}";
    }

    public void Print(){
        Console.WriteLine($@"Label base: {Environment.NewLine}{labelContent}");
    }
}

public class LabelBorder : IPrint{
    private IPrint labelBase;
    public LabelBorder(IPrint labelBase){
        this.labelBase = labelBase;
    }

    public void Print(){
        //add '..===..' line to decorate label border on original label
        //Console.WriteLine("------> Now we start adding border for label");
        Console.WriteLine("=====================================");
        labelBase.Print();
        Console.WriteLine("=====================================");
    }
}

public class LabelLogo : IPrint{
    private IPrint labelBase;
    private Type type;
    public LabelLogo(IPrint labelBase, Type type){
        this.labelBase = labelBase;
        this.type = type;
    }

    public void Print(){
        //add '..===..' line to decorate label border on original label
        //Console.WriteLine("------> Now we start adding logo for label");
        Console.WriteLine("+++++++++++");
        Console.WriteLine($"|   {type.ToString()}   |");
        Console.WriteLine("+++++++++++");
        labelBase.Print();        
    }
}

public class Test{
    public static void TestDecorateor(){
        var contact = new Contact{ Name = "BigSoft", Phone = "123456789"};
        var address = new Address{ Street = "1 Queen St", City = "Auckland", Country = "New Zealand"};
        var product = new Product{ Name = "Keyboard", Qty = 2};
        var labelBase = new LabelBase(address, contact, product);
        labelBase.Print();
        var labelLogo = new LabelLogo(labelBase, Type.DHL);
        labelLogo.Print();
        var labelBorder = new LabelBorder(labelLogo);
        labelBorder.Print();

        labelLogo = new LabelLogo(labelBase, Type.UPS);
        labelLogo.Print();        

        labelBorder = new LabelBorder(labelLogo);
        labelBorder.Print();        
    }
}