namespace PhotoShop.Core.Interfaces
{
    public interface ICommandRegistryChanged
    {
        string Partition { get; set; }
        string Key { get; set; }
    }
}
