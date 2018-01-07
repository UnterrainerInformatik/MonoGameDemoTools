// *************************************************************************** 
// This is free and unencumbered software released into the public domain.
// 
// Anyone is free to copy, modify, publish, use, compile, sell, or
// distribute this software, either in source code form or as a compiled
// binary, for any purpose, commercial or non-commercial, and by any
// means.
// 
// In jurisdictions that recognize copyright laws, the author or authors
// of this software dedicate any and all copyright interest in the
// software to the public domain. We make this dedication for the benefit
// of the public at large and to the detriment of our heirs and
// successors. We intend this dedication to be an overt act of
// relinquishment in perpetuity of all present and future rights to this
// software under copyright law.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// 
// For more information, please refer to <http://unlicense.org>
// ***************************************************************************

using InputStateManager;
using JetBrains.Annotations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGameDemoTools
{
    [PublicAPI]
    public static partial class InputManagerExtensions
    {
        public static Color ColorInput(this InputManager input, Keys? keyR, Keys? keyG, Keys? keyB, Keys? keyA, Color c,
            ref bool isModified)
        {
            Color color = c;
            int v = input.Key.Is.CtrlDown || input.Key.Is.ShiftDown ? 1 : -1;
            if (keyR != null && input.Key.Is.Down(keyR.Value))
            {
                color = new Color((color.R + v).Clamp(0, 255), color.G, color.B, color.A);
                isModified = true;
            }
            if (keyG != null && input.Key.Is.Down(keyG.Value))
            {
                color = new Color(color.R, (color.G + v).Clamp(0, 255), color.B, color.A);
                isModified = true;
            }
            if (keyB != null && input.Key.Is.Down(keyB.Value))
            {
                color = new Color(color.R, color.G, (color.B + v).Clamp(0, 255), color.A);
                isModified = true;
            }
            if (keyA != null && input.Key.Is.Down(keyA.Value))
            {
                color = new Color(color.R, color.G, color.B, (color.A + v).Clamp(0, 255));
                isModified = true;
            }
            return color;
        }
    }
}