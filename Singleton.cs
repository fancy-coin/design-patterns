namespace Singleton;

public class Sun{
    private static Sun instance;
    public static object obj = new object();
    private Sun(){        
    }

    public static Sun Get(){
        if(instance == null){
            lock(obj){
                if(instance == null){
                    instance = new Sun();
                }
            }
        }
        return instance;
    }
}

public class Test{
    public static void TestSingleton(){
        var sun1 = Sun.Get();
        var sun2 = Sun.Get();
        Console.WriteLine("Sun1 {0} Sun2", sun1 == sun2 ? "=" : "!="); 
    }
}