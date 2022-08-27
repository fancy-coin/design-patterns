using System.Text.Json;
namespace Memento;

public interface IHistory{

}

public class History{
    public List<List<string>> history = new List<List<string>>();
    private int historyIndex = -1;
    public void Backup(List<string> items){
        historyIndex++;
        var itemsCopy = JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(items));
        history.Add(itemsCopy);
    }

    public List<string> Recover(){
        --historyIndex;
        if(historyIndex == -1){
            Console.WriteLine("Cannot recover any more");
            return null;
        }
        return history.ElementAt(historyIndex);
    }
}


public class OrderDetails{
    private History history;
    public List<string> items {get;set;} = new List<string>();
    public OrderDetails(){
        this.history = new History();
        history.Backup(items);
    }

    public void AddItems(string item){
        items.Add(item);
        history.Backup(items);
    }

    public void DeleteItems(string item){
        if(items.Any(p=>p == item)){
            var delete = items.FirstOrDefault(p=>p == item);
            items.Remove(delete);
            history.Backup(items);
        }
    }

    public void Restore(){
        items = history?.Recover() ?? new List<string>();
    }

    public void Save(){
        Console.WriteLine("Order is saved. Below is order detais:");
        foreach(var item in items){
            Console.WriteLine(item);
        }
    }
}

public class Test{
    public static void TestMemento(){
        var order = new OrderDetails();
        order.AddItems("Apple");
        order.AddItems("Orange");
        order.AddItems("Banana");
        order.Save();
        order.DeleteItems("Orange");
        order.Save();
        order.Restore();
        order.Save();
    }
}
