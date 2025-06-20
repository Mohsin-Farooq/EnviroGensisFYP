using System.Runtime.InteropServices;

namespace EnviroGenesis
{
    public class WebGLTool
    {

        public static bool isMobile()
        {
            return UnityEngine.Device.Application.isMobilePlatform;
        }

    }

}