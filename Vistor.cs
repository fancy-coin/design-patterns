namespace Vistor;

public interface IVistor{
    public void Visit(Label label);
    public void Visit(Packingslip slip);
    public void Visit(Invoice invoice);
}

public abstract class Printable{
    public abstract void Accept(IVistor vistor);
    public abstract void Print();
}

public class ConcreteVistor : IVistor{
    public void Visit(Label label){
        label.Print();
    }
    public void Visit(Packingslip slip){
        slip.Print();
    }
    public void Visit(Invoice invoice){
        invoice.Print();
    }
}

public class Label : Printable{
    public override void Accept(IVistor vistor)
    {
        vistor.Visit(this);
    }
    public override void Print()
    {
        Console.WriteLine("Print label");
    }
}

public class Packingslip : Printable{
    public override void Accept(IVistor vistor)
    {
        vistor.Visit(this);
    }
    public override void Print()
    {
        Console.WriteLine("Print packing slip");
    }
}

public class Invoice : Printable{
    public override void Accept(IVistor vistor)
    {
        vistor.Visit(this);
    }
    public override void Print()
    {
        Console.WriteLine("Print invoice");
    }
}

public class Test{
    public static void TestVistor(){
        List<Printable> prints = new List<Printable>{
            new Label(),
            new Packingslip(),
            new Invoice()
        };

        IVistor vistor = new ConcreteVistor();
        foreach(var p in prints){
            p.Accept(vistor);
        }
    }
}