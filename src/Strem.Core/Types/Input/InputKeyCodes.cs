﻿namespace Strem.Core.Types.Input;

public enum InputKeyCodes
{
    LBUTTON = 1,
    RBUTTON = 2,
    CANCEL = 3,
    MBUTTON = 4,
    XBUTTON1 = 5,
    XBUTTON2 = 6,
    BACK = 8,
    TAB = 9,
    CLEAR = 12, // 0x0000000C
    RETURN = 13, // 0x0000000D
    SHIFT = 16, // 0x00000010
    CONTROL = 17, // 0x00000011
    MENU = 18, // 0x00000012
    PAUSE = 19, // 0x00000013
    CAPITAL = 20, // 0x00000014
    HANGEUL = 21, // 0x00000015
    HANGUL = 21, // 0x00000015
    KANA = 21, // 0x00000015
    JUNJA = 23, // 0x00000017
    FINAL = 24, // 0x00000018
    HANJA = 25, // 0x00000019
    KANJI = 25, // 0x00000019
    ESCAPE = 27, // 0x0000001B
    CONVERT = 28, // 0x0000001C
    NONCONVERT = 29, // 0x0000001D
    ACCEPT = 30, // 0x0000001E
    MODECHANGE = 31, // 0x0000001F
    SPACE = 32, // 0x00000020
    PRIOR = 33, // 0x00000021
    NEXT = 34, // 0x00000022
    END = 35, // 0x00000023
    HOME = 36, // 0x00000024
    LEFT = 37, // 0x00000025
    UP = 38, // 0x00000026
    RIGHT = 39, // 0x00000027
    DOWN = 40, // 0x00000028
    SELECT = 41, // 0x00000029
    PRINT = 42, // 0x0000002A
    EXECUTE = 43, // 0x0000002B
    SNAPSHOT = 44, // 0x0000002C
    INSERT = 45, // 0x0000002D
    DELETE = 46, // 0x0000002E
    HELP = 47, // 0x0000002F
    VK_0 = 48, // 0x00000030
    VK_1 = 49, // 0x00000031
    VK_2 = 50, // 0x00000032
    VK_3 = 51, // 0x00000033
    VK_4 = 52, // 0x00000034
    VK_5 = 53, // 0x00000035
    VK_6 = 54, // 0x00000036
    VK_7 = 55, // 0x00000037
    VK_8 = 56, // 0x00000038
    VK_9 = 57, // 0x00000039
    VK_A = 65, // 0x00000041
    VK_B = 66, // 0x00000042
    VK_C = 67, // 0x00000043
    VK_D = 68, // 0x00000044
    VK_E = 69, // 0x00000045
    VK_F = 70, // 0x00000046
    VK_G = 71, // 0x00000047
    VK_H = 72, // 0x00000048
    VK_I = 73, // 0x00000049
    VK_J = 74, // 0x0000004A
    VK_K = 75, // 0x0000004B
    VK_L = 76, // 0x0000004C
    VK_M = 77, // 0x0000004D
    VK_N = 78, // 0x0000004E
    VK_O = 79, // 0x0000004F
    VK_P = 80, // 0x00000050
    VK_Q = 81, // 0x00000051
    VK_R = 82, // 0x00000052
    VK_S = 83, // 0x00000053
    VK_T = 84, // 0x00000054
    VK_U = 85, // 0x00000055
    VK_V = 86, // 0x00000056
    VK_W = 87, // 0x00000057
    VK_X = 88, // 0x00000058
    VK_Y = 89, // 0x00000059
    VK_Z = 90, // 0x0000005A
    LWIN = 91, // 0x0000005B
    RWIN = 92, // 0x0000005C
    APPS = 93, // 0x0000005D
    SLEEP = 95, // 0x0000005F
    NUMPAD0 = 96, // 0x00000060
    NUMPAD1 = 97, // 0x00000061
    NUMPAD2 = 98, // 0x00000062
    NUMPAD3 = 99, // 0x00000063
    NUMPAD4 = 100, // 0x00000064
    NUMPAD5 = 101, // 0x00000065
    NUMPAD6 = 102, // 0x00000066
    NUMPAD7 = 103, // 0x00000067
    NUMPAD8 = 104, // 0x00000068
    NUMPAD9 = 105, // 0x00000069
    MULTIPLY = 106, // 0x0000006A
    ADD = 107, // 0x0000006B
    SEPARATOR = 108, // 0x0000006C
    SUBTRACT = 109, // 0x0000006D
    DECIMAL = 110, // 0x0000006E
    DIVIDE = 111, // 0x0000006F
    F1 = 112, // 0x00000070
    F2 = 113, // 0x00000071
    F3 = 114, // 0x00000072
    F4 = 115, // 0x00000073
    F5 = 116, // 0x00000074
    F6 = 117, // 0x00000075
    F7 = 118, // 0x00000076
    F8 = 119, // 0x00000077
    F9 = 120, // 0x00000078
    F10 = 121, // 0x00000079
    F11 = 122, // 0x0000007A
    F12 = 123, // 0x0000007B
    F13 = 124, // 0x0000007C
    F14 = 125, // 0x0000007D
    F15 = 126, // 0x0000007E
    F16 = 127, // 0x0000007F
    F17 = 128, // 0x00000080
    F18 = 129, // 0x00000081
    F19 = 130, // 0x00000082
    F20 = 131, // 0x00000083
    F21 = 132, // 0x00000084
    F22 = 133, // 0x00000085
    F23 = 134, // 0x00000086
    F24 = 135, // 0x00000087
    NUMLOCK = 144, // 0x00000090
    SCROLL = 145, // 0x00000091
    LSHIFT = 160, // 0x000000A0
    RSHIFT = 161, // 0x000000A1
    LCONTROL = 162, // 0x000000A2
    RCONTROL = 163, // 0x000000A3
    LMENU = 164, // 0x000000A4
    RMENU = 165, // 0x000000A5
    BROWSER_BACK = 166, // 0x000000A6
    BROWSER_FORWARD = 167, // 0x000000A7
    BROWSER_REFRESH = 168, // 0x000000A8
    BROWSER_STOP = 169, // 0x000000A9
    BROWSER_SEARCH = 170, // 0x000000AA
    BROWSER_FAVORITES = 171, // 0x000000AB
    BROWSER_HOME = 172, // 0x000000AC
    VOLUME_MUTE = 173, // 0x000000AD
    VOLUME_DOWN = 174, // 0x000000AE
    VOLUME_UP = 175, // 0x000000AF
    MEDIA_NEXT_TRACK = 176, // 0x000000B0
    MEDIA_PREV_TRACK = 177, // 0x000000B1
    MEDIA_STOP = 178, // 0x000000B2
    MEDIA_PLAY_PAUSE = 179, // 0x000000B3
    LAUNCH_MAIL = 180, // 0x000000B4
    LAUNCH_MEDIA_SELECT = 181, // 0x000000B5
    LAUNCH_APP1 = 182, // 0x000000B6
    LAUNCH_APP2 = 183, // 0x000000B7
    OEM_1 = 186, // 0x000000BA
    OEM_PLUS = 187, // 0x000000BB
    OEM_COMMA = 188, // 0x000000BC
    OEM_MINUS = 189, // 0x000000BD
    OEM_PERIOD = 190, // 0x000000BE
    OEM_2 = 191, // 0x000000BF
    OEM_3 = 192, // 0x000000C0
    OEM_4 = 219, // 0x000000DB
    OEM_5 = 220, // 0x000000DC
    OEM_6 = 221, // 0x000000DD
    OEM_7 = 222, // 0x000000DE
    OEM_8 = 223, // 0x000000DF
    OEM_102 = 226, // 0x000000E2
    PROCESSKEY = 229, // 0x000000E5
    PACKET = 231, // 0x000000E7
    ATTN = 246, // 0x000000F6
    CRSEL = 247, // 0x000000F7
    EXSEL = 248, // 0x000000F8
    EREOF = 249, // 0x000000F9
    PLAY = 250, // 0x000000FA
    ZOOM = 251, // 0x000000FB
    NONAME = 252, // 0x000000FC
    PA1 = 253, // 0x000000FD
    OEM_CLEAR = 254, // 0x000000FE
}