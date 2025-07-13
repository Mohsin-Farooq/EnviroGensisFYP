using UnityEngine;

public class LowSpecProfile : IDeviceProfile
{
    public bool IsMatch(int ramMB, int processorCount, int graphicsMemoryMB)
    {
        return ramMB <= 2048 && processorCount < 8 && graphicsMemoryMB <= 512;
    }

    public void ApplySettings()
    {
        QualitySettings.SetQualityLevel(0, true); 
        Application.targetFrameRate = 60;
        QualitySettings.shadowDistance = 0;
        QualitySettings.globalTextureMipmapLimit = 2;
        Shader.globalMaximumLOD = 300;
    }
}
