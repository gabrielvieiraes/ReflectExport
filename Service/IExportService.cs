
namespace ReflectExport.Service
{
    public interface IExportService
    {
        string ExportCSV<T>(T values);
        string ExportJson<T>(T values);
    }
}