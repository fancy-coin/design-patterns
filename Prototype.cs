using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype;

[Serializable]
public class Label : ICloneable{
    public Guid Id { get; set; }
    public string Type { get; set; } 
    public string Size { get; set; } 
    public DateTime PrintDate { get; set;}

    public Label(){
        Id = new Guid();
        Type = "DHL";
        Size = "A4";
        PrintDate = DateTime.Now;
    }

    public void Print(){
        Console.WriteLine($"Shipment: {this.Id}, Type: {this.Type}, Size: {this.Size}, Print Date: {this.PrintDate}");
    }

    public object Clone(){
        var bytes =SerializeObject(this);
        return DeserializeObject(bytes);
    }

    
    private static byte[] SerializeObject(object obj){
        if(obj == null){
            return null;
        }

        MemoryStream ms = new MemoryStream();
        BinaryFormatter formatter = new BinaryFormatter(); 
        formatter.Serialize(ms, obj);
        ms.Position = 0;
        byte[] bytes = new byte[ms.Length];
        ms.Read(bytes, 0, bytes.Length);
        ms.Close();
        return bytes;
    }

    private static object DeserializeObject(byte[] bytes){
        object obj = null;
        if(bytes == null){
            return null;
        }
        MemoryStream ms = new MemoryStream(bytes);
        ms.Position = 0;
        BinaryFormatter formatter = new ();
        obj = formatter.Deserialize(ms);
        ms.Close();
        return obj;
        
    }
}

public class Test{
    public static void TestPrototype(){
        var label = new Label();
        label.Print();
        var cloneLabel = (Label)label.Clone();
        cloneLabel.Size = "A5";
        cloneLabel.Print();
    }
}