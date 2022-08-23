namespace Mediator;

public interface INotice{
    public void Notice(Component component, string message);
}

public abstract class Component{
    public INotice panel;
    public Component(INotice panel){
        this.panel = panel;
    }    
}

public class UserNameTextBox : Component{
    private string input;
    public UserNameTextBox(INotice panel) : base(panel){

    }

    public void CleanInput(){
        input = string.Empty;
        Console.WriteLine($"Clean username input");
    }

    public void SendNotice(string name = "hello,world"){
        Console.WriteLine($"UserNameTextBox is sending input: {name}");    
        panel.Notice(this, name);
    }

    public void GetNotice(){
        Console.WriteLine("UserNameTextBox receives notice");            
    }
}

public class Validator : Component{
    public Validator(INotice panel) : base(panel){

    }

    public void Validate(string name){
        Console.WriteLine($"Validation is starting...");
        var message = "name is valid";
        if(string.IsNullOrWhiteSpace(name) || name.Length > 5){
            message = "name is invalid";
        }
        Console.WriteLine($"Validation result: {message}");
        panel.Notice(this, message);
    } 
}

public class RegisterButton : Component{
    public RegisterButton(INotice panel) : base(panel){

    }

    public void Click(){
        Console.WriteLine("Register button is clicked");
        panel.Notice(this, "Register");
    } 
}

public class Panel : INotice{
    private UserNameTextBox username;
    private Validator validator;
    private RegisterButton btn;

    public Panel(){}
    public Panel SetUserNameTextBox(UserNameTextBox usernametbx){
        username = usernametbx;
        return this;
    }
    public Panel SetValidator(Validator validator){
        this.validator = validator;
        return this;
    }
    public Panel SetRegisterButton(RegisterButton btn){
        this.btn = btn;
        return this;
    }

    public void Notice(Component comp, string message){
        if(comp == username){
            Console.WriteLine("Panel receives message from UserNameTextBox");
            Console.WriteLine("Panel sends username to validator");
            validator.Validate(message);
        }
        else if(comp == validator){
            Console.WriteLine("Panel receives message from Validator");
            if(message == "name is invalid"){
                username.CleanInput();
            }
        }
        else if(comp == btn){
            Console.WriteLine("Panel receives message from Register Button");
            if(message == "Register"){
                username.SendNotice();
            }            
        }
    }
}


public class Test{
    public static void TestMediator(){
        Panel panel = new Panel();
        var username = new UserNameTextBox(panel);
        var validator = new Validator(panel);
        var btn = new RegisterButton(panel);
        panel.SetUserNameTextBox(username)
             .SetValidator(validator)
             .SetRegisterButton(btn);

        username.SendNotice("Alice");
        username.SendNotice("Robert");
        btn.Click();
    }
}