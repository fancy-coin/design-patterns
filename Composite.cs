namespace Composite;


public abstract class Branch{
    protected List<Branch> branches = null;
    protected int level;
    protected string name;
    protected string location;
    public Branch(int level, string name, string location){
        this.level = level;
        this.name = name;
        this.location = location;
    }

    public virtual void Add(Branch branch){
        Console.WriteLine("Branch can't be added");
    }

    public virtual void Display(){
        Console.WriteLine($"{new String(' ', level*4)}{name} , location: {location}");
        if(branches?.Any() ?? false){
            foreach(var b in branches){
                b.Display();
            }
        }
    }
}

public class DHL : Branch{
    public DHL(int level, string name, string location) : base(level, name, location){              
    }

    public override void Add(Branch branch){
        if(branches == null){
            branches = new List<Branch>();
        }
        branches.Add(branch);
    }    
}

public class DHLShop : Branch{
    public DHLShop(int level, string name, string location) : base(level, name, location){          
    }    
}

public class Test{
    public static void TestComposite(){
        var headquarter = new DHL(0, "Head Quarter", "Germany");
        var aucompany = new DHL(1, "Sub Company", "Australia");
        var nzcompany = new DHL(1, "Sub Company", "New Zealand");
        var uscompany = new DHL(1, "Sub Company", "United States");
        headquarter.Add(aucompany);
        headquarter.Add(nzcompany);
        headquarter.Add(uscompany);
        var aucklandshop = new DHL(2, "Shop", "Auckland");
        var wellingtonshop = new DHL(2, "Shop", "Wellington");
        var hamiltonshop = new DHL(2, "Shop", "Hamilton");
        var newyorkshop = new DHL (2, "Shop", "New York");
        var sydneyshop = new DHL (2, "Shop", "Sydney");
        var perthshop = new DHL (2, "Shop", "Perth");
        nzcompany.Add(aucklandshop);
        nzcompany.Add(wellingtonshop);
        nzcompany.Add(hamiltonshop);
        aucompany.Add(sydneyshop);
        aucompany.Add(perthshop);
        uscompany.Add(newyorkshop);
        headquarter.Display();
    }
}