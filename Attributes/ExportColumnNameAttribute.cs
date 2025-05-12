namespace ReflectExport.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExportColumnNameAttribute : Attribute
    {
        public string Name { get; set; }
        public ExportColumnNameAttribute(string name)
        {
            Name = name;
        }
    }
}
