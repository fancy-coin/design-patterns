using System.Collections;
namespace Iterator;

public interface IIterator{
    public bool HasNext();
    public object Next();
}

public class CarrierIterator : IIterator{
    private Aggregate objs;
    private int index;
    public CarrierIterator(Aggregate aggregate){
        objs = aggregate;
        index = 0;
    }

    public bool HasNext(){
        return index < objs.GetLength();
    }

    public object Next(){
        var obj = objs.Get(index);
        index++;
        return obj;
    }
}

public abstract class Aggregate{
    public abstract IIterator CreateIterator();
    public abstract int GetLength();
    public abstract object Get(int index);
    public abstract void Add(object obj);
}

public class Carriers : Aggregate{

    private object[] objects = new object[10];
    private int last = 0;
    public override IIterator CreateIterator(){
        return new CarrierIterator(this);
    }

    public override int GetLength(){
        return last;
    }

    public override object Get(int index){
        return objects[index];
    }

    public override void Add(object obj)
    {
        objects[last++] = obj;
    }
}

public class Test{
    public static void TestIterator(){
        var carriers = new Carriers();
        carriers.Add("DHL");
        carriers.Add("AusPost");
        carriers.Add("UPS");
        carriers.Add("Fedex");
        var iterator = carriers.CreateIterator();
        while(iterator.HasNext()){
            var carrier = iterator.Next();
            Console.WriteLine(carrier);
        }
    }
}
