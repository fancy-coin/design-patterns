namespace ResponsibilityChain;

public class Chain{
    protected Chain? next{get;set;}

    public Chain SetNext(Chain next){
        this.next = next;
        return this.next;
    }

    public virtual void Process(string condition){        
    }
}

public class Dev : Chain{
    public override void Process(string condition)
    {
        if(condition == "common bug"){
            Console.WriteLine("Dev can pick it up");
        }
        else{
            Console.WriteLine("Dev can't do it. Pass it to dev manager");
            this.next.Process(condition);
        }
    }
}

public class DevManager : Chain{
    public override void Process(string condition)
    {
        if(condition == "serious bug"){
            Console.WriteLine("Dev manager can pick it up");
        }
        else{
            Console.WriteLine("Dev manager can't do it. Pass it to CTO");
            this.next.Process(condition);
        }
    }
}

public class CTO : Chain{
    public override void Process(string condition){ 
        Console.WriteLine("CTO can pick it up");
    }
}

public class Test{
    public static void TestResponsibilityChain(){
        var dev = new Dev();
        dev.SetNext(new DevManager()).SetNext(new CTO());
        dev.Process("common bug");
        dev.Process("serious bug");
        dev.Process("hard bug");
    }
}