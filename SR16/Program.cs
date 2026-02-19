using System;
using System.Text;

namespace SR16
{
    // Інтерфейси згідно з Варіантом 4
    public interface IDataSource { string GetData(); }
    public interface IDataProcessor { string Process(string data); }
    public interface IPdfFormatter { byte[] FormatToPdf(string processedData); }
    public interface IFileSaver { void Save(byte[] fileData, string filename); }

    // Реалізація заглушок
    public class ApiDataSource : IDataSource { public string GetData() => "Raw Data from API"; }
    public class ReportProcessor : IDataProcessor { public string Process(string data) => $"Processed ({data})"; }
    public class PdfFormatService : IPdfFormatter { public byte[] FormatToPdf(string d) => Encoding.UTF8.GetBytes(d); }
    public class DiskSaver : IFileSaver { public void Save(byte[] d, string n) => Console.WriteLine($"Saved {n} to Disk."); }

    // Головний сервіс
    public class ReportService
    {
        private readonly IDataSource _src;
        private readonly IDataProcessor _proc;
        private readonly IPdfFormatter _form;
        private readonly IFileSaver _save;

        public ReportService(IDataSource src, IDataProcessor proc, IPdfFormatter form, IFileSaver save)
        {
            _src = src; _proc = proc; _form = form; _save = save;
        }

        public void Execute()
        {
            var data = _src.GetData();
            var processed = _proc.Process(data);
            var pdf = _form.FormatToPdf(processed);
            _save.Save(pdf, "report.pdf");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var service = new ReportService(new ApiDataSource(), new ReportProcessor(), new PdfFormatService(), new DiskSaver());
            service.Execute();
            Console.WriteLine("SR16 Варіант 4 виконано успішно.");
        }
    }
}
