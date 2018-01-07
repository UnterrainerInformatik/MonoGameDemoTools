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
using Microsoft.Xna.Framework.Input;

namespace MonoGameDemoTools
{
    public static partial class InputManagerExtensions
    {
        public static int IntInput(this InputManager input, Keys down, Keys up, int step, int value, ref bool isModified,
            bool repeat = false)
        {
            int v = 0;
            if (!repeat && input.Key.Is.Press(up) || repeat && input.Key.Is.Down(up))
            {
                v = step;
                isModified = true;
            }
            if (!repeat && input.Key.Is.Press(down) || repeat && input.Key.Is.Down(down))
            {
                v = -step;
                isModified = true;
            }
            return value + v;
        }

        public static int IntInput(this InputManager input, Keys down, int step, int value, ref bool isModified,
            bool repeat = false)
        {
            int mult = input.Key.Is.CtrlDown || input.Key.Is.ShiftDown ? -1 : 1;
            int v = 0;
            if (!repeat && input.Key.Is.Press(down) || repeat && input.Key.Is.Down(down))
            {
                v = -step * mult;
                isModified = true;
            }
            return value + v;
        }
    }
}