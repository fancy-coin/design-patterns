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
    }

    private static void ExecutePattern(string patternName, Action pattern){
        Console.WriteLine($"****** Start {patternName} Test ******");
        pattern();
        Console.WriteLine();
    }
}