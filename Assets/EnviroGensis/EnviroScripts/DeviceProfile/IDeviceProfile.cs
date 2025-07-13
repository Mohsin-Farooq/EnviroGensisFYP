public interface IDeviceProfile
{
    bool IsMatch(int ramMB, int processorCount, int graphicsMemoryMB);
    void ApplySettings();
}