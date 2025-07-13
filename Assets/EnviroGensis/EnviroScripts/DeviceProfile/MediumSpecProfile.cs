using UnityEngine;

public class MediumSpecProfile : IDeviceProfile
{
    public bool IsMatch(int ramMB, int processorCount, int graphicsMemoryMB)
    {
        return ramMB <= 4096 && processorCount >= 8 && graphicsMemoryMB > 512;
    }

    public void ApplySettings()
    {
        QualitySettings.SetQualityLevel(1, true); 
        Application.targetFrameRate = 60;
        QualitySettings.shadowDistance = 0;
        Shader.globalMaximumLOD = 400;
        QualitySettings.globalTextureMipmapLimit = 1;
    }
}
