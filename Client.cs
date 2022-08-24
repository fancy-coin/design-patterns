public class Client{
    public static void TestAllPatterns(){
        ExecutePattern("Singleton", Singleton.Test.TestSingleton);
        ExecutePattern("SimpleFactory", SimpleFactory.Test.TestSimpleFactory);
        ExecutePattern("FactoryMethod", FactoryMethod.Test.TestFactoryMethod);
        ExecutePattern("AbstractFactory", AbstractFactory.Test.TestAbstractFactory);
        ExecutePattern("ResponsibilityChain", ResponsibilityChain.Test.TestResponsibilityChain);
        ExecutePattern("Strategy", Strategy.Test.TestStrategy);  
        ExecutePattern("Prototype", Prototype.Test.TestPrototype);  
        ExecutePattern("Flyweight", Flyweight.Test.TestFlyweight);
        ExecutePattern("Facade", Facede.Test.TestFacade); 
        ExecutePattern("Adapter", Adapter.Test.TestAdapter);
        ExecutePattern("Template", Template.Test.TestTemplate);   
        ExecutePattern("Composite", Composite.Test.TestComposite);   
        ExecutePattern("Builder", Builder.Test.TestBuilder);
        ExecutePattern("Proxy", Proxy.Test.TestProxy);
        ExecutePattern("Decorator", Decorator.Test.TestDecorateor);
        ExecutePattern("State", State.Test.TestState);
        ExecutePattern("Mediator", Mediator.Test.TestMediator);
        ExecutePattern("Command", Command.Test.TestCommand);
    }

    private static void ExecutePattern(string patternName, Action pattern){
        Console.WriteLine($"###########################################");
        Console.WriteLine($"          Start {patternName} Test         ");
        Console.WriteLine($"###########################################");
        pattern();
        Console.WriteLine();
    }
}