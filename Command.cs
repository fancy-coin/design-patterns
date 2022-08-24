namespace Command;

public interface ICommand{
    public void Execute();
}

public class LabelPrinter{
    public void Print(){
        Console.WriteLine("Execute printing label command");
    }
}

public class LabelDownloader{
    public void Download(){
        Console.WriteLine("Execute downloading label command");
    }
}

public class PrintLabel : ICommand{
    private LabelPrinter printer;
    public PrintLabel(LabelPrinter printer){
        this.printer = printer;
    }

    public void Execute(){
        printer.Print();
    }
}

public class DownloadLabel : ICommand{
    private LabelDownloader downloader;
    public DownloadLabel(LabelDownloader downloader){
        this.downloader = downloader;
    }

    public void Execute(){
        downloader.Download();
    }
}

public class Invoker : ICommand{
    public List<ICommand> commands = new List<ICommand>();
    public void Add(ICommand command){
        commands.Add(command);
    }

    public void Execute(){
        foreach(var c in commands){
            c.Execute();
        }
        commands.Clear();
    }
}

public class Test{
    public static void TestCommand(){
        var invoker = new Invoker();

        ICommand printlabel = new PrintLabel(new LabelPrinter());
        invoker.Add(printlabel);
        invoker.Execute();

        ICommand downloadLabel = new DownloadLabel(new LabelDownloader());
        invoker.Add(downloadLabel);
        invoker.Execute();
    }
}

