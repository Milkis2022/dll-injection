using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    // Windows API 함수 선언
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    // 상수 정의
    const uint WM_SETTEXT = 0x000C;

    static void Main()
    {
        // Notepad 프로세스 시작
        Process process = Process.Start("notepad.exe");

        // Notepad의 메인 창 핸들 가져오기
        IntPtr notepadHandle = FindWindow("Notepad", null);

        // Notepad의 텍스트 입력 창 핸들 가져오기
        IntPtr editHandle = FindWindowEx(notepadHandle, IntPtr.Zero, "Edit", null);

        // 텍스트 파일에 쓸 내용
        string text = "Hello, Notepad!";

        // Notepad에 텍스트 쓰기
        SendMessage(editHandle, WM_SETTEXT, IntPtr.Zero, Marshal.StringToHGlobalAuto(text));

        // Notepad 프로세스 종료
        process.Close();
    }
}
