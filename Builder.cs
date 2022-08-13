namespace Builder;

public class Contact{
    public string Name {get;set;}
    public string Phone {get;set;}
    public string ToString(){
        return $"Name: {Name}, Phone: {Phone}";
    }
}

public class Address{
    public string Street {get;set;}
    public string City {get;set;}
    public string Country {get;set;}
    public string ToString(){
        return $"Country: {Country}, City: {City}, Street: {Street}";
    }
}

public class Product{
    public string Name {get;set;}
    public int Qty {get;set;}
    public string ToString(){
        return $"Product: {Name}, Quantity: {Qty}";
    }
}

public class Label{
    public Dictionary<int, string> content = new Dictionary<int, string>();

    public void SetLabelType(string type){
        content.Add(0, type);
    }

    public void SetContact(string contact){
        content.Add(1, contact);
    }
    public void SetAddress(string address){
        content.Add(2, address);
    }  
    public void SetProduct(string product){
        content.Add(2, product);
    }  
    public void Display(){
        var input = content.OrderBy(p=>p.Key).Select(p=>p.Value.ToString()).Aggregate((x,y)=>x + "\n" + y);
        Console.WriteLine(input);
    }
}

public interface LabelBuilder{
    public void ConstructHeaderLine();
    public void ConstructContactLine(Contact contact);
    public void ConstructAddressLine(Address address);
    public void ConstructItemsLine(Product product);
    public Label Get();
}

public class Director{
    private LabelBuilder builder;
    public Director(LabelBuilder builder){
        this.builder = builder;
    }
    public void ConstructLabel(){
        var contact = new Contact{ Name = "BigSoft", Phone = "123456789"};
        var address = new Address{ Street = "1 Queen St", City = "Auckland", Country = "New Zealand"};
        var product = new Product{ Name = "Keyboard", Qty = 2};
        builder.ConstructHeaderLine();
        builder.ConstructContactLine(contact);
        builder.ConstructAddressLine(address);
        builder.ConstructItemsLine(product);
    }
    public Label GetLabel(){
        ConstructLabel();
        return builder.Get();
    }
}

public class DHL : LabelBuilder{
    private Label label;
    public DHL(){
        label = new Label();
    }

    public void ConstructHeaderLine(){
        label.content.Add(0, "========== DHL Label==========");
    }
    public void ConstructContactLine(Contact contact){
        Console.WriteLine("Start constructing contact details...");
        var contactString = $"Name: {contact.Name}     Phone: {contact.Phone}";
        label.content.Add(1, contactString);
    }
    public void ConstructAddressLine(Address address){
        Console.WriteLine("Start constructing address details...");
        var addressString = $@"{address.Street}{Environment.NewLine}{address.City}, {address.Country}";
        label.content.Add(2, addressString);                     
    }
    public void ConstructItemsLine(Product product){
        Console.WriteLine("Start constructing product details...");
        var productString = $@"Item: {product.Name}  Quantity: {product.Qty}";
        label.content.Add(3, productString); 
        label.content.Add(4, "==============================");         
    }
    public Label Get(){
        return label;
    }
}

public class UPS : LabelBuilder{
    private Label label;
    public UPS(){
        label = new Label();
    }

    public void ConstructHeaderLine(){
        label.content.Add(0, "********** UPS Label**********");
    }
    public void ConstructContactLine(Contact contact){
        Console.WriteLine("Start constructing contact details...");
        var contactString = $@"Name: {contact.Name}{Environment.NewLine}Phone: {contact.Phone}";
        label.content.Add(1, contactString);
    }
    public void ConstructAddressLine(Address address){
        Console.WriteLine("Start constructing address details...");
        var addressString = 
        $@"Street : {address.Street}{Environment.NewLine}City   : {address.City}{Environment.NewLine}Country: {address.Country}";
        label.content.Add(2, addressString);                     
    }
    public void ConstructItemsLine(Product product){
        Console.WriteLine("Start constructing product details...");
        var productString = $@"Product: {product.Name}  Qty: {product.Qty}";
        label.content.Add(3, productString);   
        label.content.Add(4, "******************************");        
    }
    public Label Get(){
        return label;
    }
}

public class Test{
    public static void TestBuilder(){
        LabelBuilder build = new DHL();
        var director = new Director(new DHL());
        var label = director.GetLabel();
        label.Display();
        director = new Director(new UPS());
        label = director.GetLabel();
        label.Display();
    }
}