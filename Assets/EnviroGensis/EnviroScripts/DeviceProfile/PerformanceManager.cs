using UnityEngine;
using System.Collections.Generic;
public class PerformanceManager : MonoBehaviour
{
    private List<IDeviceProfile> profiles;

    void Awake()
    {
        profiles = new List<IDeviceProfile>
        {
            new LowSpecProfile(),
            new MediumSpecProfile(),
            new HighSpecProfile()
        };
        Debug.unityLogger.logEnabled = false;
    }

    void Start()
    {
        int ramMB = SystemInfo.systemMemorySize;
        int processorCount = SystemInfo.processorCount;
        int graphicsMemoryMB = SystemInfo.graphicsMemorySize;

        foreach (var profile in profiles)
        {
            if (profile.IsMatch(ramMB, processorCount, graphicsMemoryMB))
            {
                profile.ApplySettings();
                return;
            }
        }
        
        new MediumSpecProfile().ApplySettings();
    }
}
