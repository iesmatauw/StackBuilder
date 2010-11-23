using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Graphics
{
    public abstract class Drawable
    {
        public virtual void DrawBegin(Graphics3D graphics) { }
        public abstract void Draw(Graphics3D graphics);
        public virtual void DrawEnd(Graphics3D graphics) { }
    }
}
