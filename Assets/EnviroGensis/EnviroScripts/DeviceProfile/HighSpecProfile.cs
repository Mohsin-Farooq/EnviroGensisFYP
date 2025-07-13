using UnityEngine;

public class HighSpecProfile : IDeviceProfile
{
    public bool IsMatch(int ramMB, int processorCount, int graphicsMemoryMB)
    {
        return ramMB > 4096 && processorCount >= 8 && graphicsMemoryMB > 512;
    }

    public void ApplySettings()
    {
        QualitySettings.SetQualityLevel(2, true); 
        Application.targetFrameRate = 60;
        QualitySettings.shadowDistance = 150;
        Shader.globalMaximumLOD = 600;
        QualitySettings.globalTextureMipmapLimit = 0;
    }
}
