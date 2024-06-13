using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;
using Windows.Win32.UI.WindowsAndMessaging;

namespace TemplateCreator.Features.Windows;

public static class WindowCaptureHelper
{
    public static Bitmap CaptureClientWindowImage(Process process)
    {
        var hwnd = new HWND(process.MainWindowHandle);
        PInvoke.SetForegroundWindow(hwnd);

        TITLEBARINFO titleBarInfo = new();
        titleBarInfo.cbSize = (uint)Marshal.SizeOf(typeof(TITLEBARINFO));
        PInvoke.GetTitleBarInfo(hwnd, ref titleBarInfo);

        WINDOWINFO windowInfo = new();
        windowInfo.cbSize = (uint)Marshal.SizeOf(typeof(WINDOWINFO));
        PInvoke.GetWindowInfo(hwnd, ref windowInfo);

        int width = windowInfo.rcClient.Width;
        int height = windowInfo.rcClient.Height - titleBarInfo.rcTitleBar.Height - (int)windowInfo.cyWindowBorders;

        HDC hdcSrc = PInvoke.GetDC(hwnd);
        HDC hdcDest = PInvoke.CreateCompatibleDC(hdcSrc);
        HBITMAP hBitmap = PInvoke.CreateCompatibleBitmap(hdcSrc, width, height);
        HGDIOBJ hOld = PInvoke.SelectObject(hdcDest, hBitmap);

        PInvoke.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, titleBarInfo.rcTitleBar.Height + (int)windowInfo.cyWindowBorders, ROP_CODE.SRCCOPY);

        PInvoke.SelectObject(hdcDest, hOld);
        PInvoke.DeleteDC(hdcDest);
        PInvoke.ReleaseDC(hwnd, hdcSrc);

        Bitmap bmp = Bitmap.FromHbitmap(hBitmap.Value);
        PInvoke.DeleteObject(hBitmap);

        return bmp;
    }
}