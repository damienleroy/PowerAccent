using Vanara.PInvoke;

namespace PowerAccent.Core;

public enum LetterKey
{
    A = User32.VK.VK_A,
    C = User32.VK.VK_C,
    E = User32.VK.VK_E,
    G = User32.VK.VK_G,
    I = User32.VK.VK_I,
    L = User32.VK.VK_L,
    N = User32.VK.VK_N,
    O = User32.VK.VK_O,
    S = User32.VK.VK_S,
    T = User32.VK.VK_T,
    U = User32.VK.VK_U,
    Y = User32.VK.VK_Y,
    Z = User32.VK.VK_Z,
    _ = User32.VK.VK_OEM_COMMA,
}

public enum TriggerKey
{
    Left = User32.VK.VK_LEFT,
    Right = User32.VK.VK_RIGHT,
    Space = User32.VK.VK_SPACE
}
