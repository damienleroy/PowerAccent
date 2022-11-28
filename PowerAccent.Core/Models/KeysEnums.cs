using Vanara.PInvoke;

namespace PowerAccent.Core;

public enum LetterKey : uint
{
    _0 = User32.VK.VK_0,
    _1 = User32.VK.VK_1,
    _2 = User32.VK.VK_2,
    _3 = User32.VK.VK_3,
    _4 = User32.VK.VK_4,
    _5 = User32.VK.VK_5,
    _6 = User32.VK.VK_6,
    _7 = User32.VK.VK_7,
    _8 = User32.VK.VK_8,
    _9 = User32.VK.VK_9,
    A = User32.VK.VK_A,
    B = User32.VK.VK_B,
    C = User32.VK.VK_C,
    D = User32.VK.VK_D,
    E = User32.VK.VK_E,
    F = User32.VK.VK_F,
    G = User32.VK.VK_G,
    H = User32.VK.VK_H,
    I = User32.VK.VK_I,
    J = User32.VK.VK_J,
    K = User32.VK.VK_K,
    L = User32.VK.VK_L,
    M = User32.VK.VK_M,
    N = User32.VK.VK_N,
    O = User32.VK.VK_O,
    P = User32.VK.VK_P,
    R = User32.VK.VK_R,
    S = User32.VK.VK_S,
    T = User32.VK.VK_T,
    U = User32.VK.VK_U,
    V = User32.VK.VK_V,
    W = User32.VK.VK_W,
    X = User32.VK.VK_X,
    Y = User32.VK.VK_Y,
    Z = User32.VK.VK_Z,
    _ = User32.VK.VK_OEM_COMMA,
}

public enum TriggerKey : uint
{
    Left = User32.VK.VK_LEFT,
    Right = User32.VK.VK_RIGHT,
    Space = User32.VK.VK_SPACE,
}

public enum BackwardKey : uint
{
    LeftShift = User32.VK.VK_LSHIFT,
    RightShift = User32.VK.VK_RSHIFT,
}