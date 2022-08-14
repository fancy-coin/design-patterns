namespace State;

public enum UserAction{
    Upgrade,
    Degrade

}

public abstract class UserState{
    protected virtual string type => "user";
    public virtual void PrintNonColorLabel(){ 
        Console.WriteLine("You don't have the permission to print black&white label");      
    }

    public virtual void PrintColorLabel(){        
        Console.WriteLine("You don't have the permission to print color label");       
    }

    public virtual void PrintReturnLabel(){        
        Console.WriteLine("You don't have the permission to print return label");       
    }

    public abstract UserState Upgrade();
    public abstract UserState Degrade();
    public virtual string GetUserType(){
        return type;
    }
}

public class SilverUser : UserState{
    protected override string type => "Silver";
    public override void PrintNonColorLabel(){ 
        Console.WriteLine("You have the permission to print black&white label");      
    }

    public override UserState Upgrade()
    {
        Console.WriteLine("Your have been upgraded to gold user");
        return new GoldUser();
    }

    public override UserState Degrade()
    {
        Console.WriteLine("Your level can't be lower than silver user");
        return this;
    }    
}

public class GoldUser : UserState{
    protected override string type => "Gold";
    public override void PrintNonColorLabel(){ 
        Console.WriteLine("You have the permission to print black&white label");      
    }

    public override void PrintColorLabel()
    {
        Console.WriteLine("You have the permission to print color label");       
    }  

    public override UserState Upgrade()
    {
        Console.WriteLine("Your have been upgraded to diamond user");
        return new DiamondUser();
    }

    public override UserState Degrade()
    {
        Console.WriteLine("Your have been degraded to silver user");
        return new SilverUser();
    }  
}

public class DiamondUser : UserState{
    protected override string type => "Diamond";

    public override void PrintNonColorLabel(){ 
        Console.WriteLine("You have the permission to print black&white label");      
    }

    public override void PrintColorLabel()
    {
        Console.WriteLine("You have the permission to print color label");       
    }

    public override void PrintReturnLabel()
    {
        Console.WriteLine("You have the permission to print return label");       
    }

    public override UserState Upgrade()
    {
        Console.WriteLine("Your level can't be higher than diamond user");
        return this;
    }

    public override UserState Degrade()
    {
        Console.WriteLine("Your have been degraded to gold user");
        return new GoldUser();
    }
}

public class User{
    private UserState state;
    public User(){
        state = new SilverUser();
    }

    public void UserDecision(UserAction action){
        if(action == UserAction.Upgrade){
            state = state.Upgrade();
        }
        else{
            state = state.Degrade();
        }
    }

    public void Print(){
        Console.WriteLine($"{state.GetUserType()} user starts printing label...");
        state.PrintNonColorLabel();
        state.PrintColorLabel();
        state.PrintReturnLabel();
        Console.WriteLine();
    }
}

public class Test{
    public static void TestState(){
        //init a silver user
        var user = new User();
        user.Print();

        //try to degrade silver user to lower level 
        user.UserDecision(UserAction.Degrade);
        user.Print();

        //upgrade silver user to gold user
        user.UserDecision(UserAction.Upgrade);
        user.Print();

        //upgrade gold user to diamond user
        user.UserDecision(UserAction.Upgrade);
        user.Print();

        //degrade diamond user to gold user
        user.UserDecision(UserAction.Degrade);
        user.Print();

        //degrade gold user to silver user
        user.UserDecision(UserAction.Degrade);
        user.Print();
    }
}