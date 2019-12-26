using Math;
using Renderer;

namespace Tracer.Core
{
    public class SceneObject
    {
        public Region ScreenRegion { get; set; }
        public Pixel[,,] Buffer;
    }
}
