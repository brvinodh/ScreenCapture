using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

internal class HotKeyWinApi
{
    public const int WmHotKey = 0x0312;

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, ModifierKeys fsModifiers, Key vk);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
}
public sealed class HotKey : IDisposable
{
    public event Action<HotKey> HotKeyPressed;

    private readonly int _id;
    private bool _isKeyRegistered;
    readonly IntPtr _handle;

    public HotKey(ModifierKeys modifierKeys, Key key, Window window)
        : this(modifierKeys, key, new WindowInteropHelper(window))
    {
        Contract.Requires(window != null);
    }

    public HotKey(ModifierKeys modifierKeys, Key key, WindowInteropHelper window)
        : this(modifierKeys, key, window.Handle)
    {
        Contract.Requires(window != null);
    }

    public HotKey(ModifierKeys modifierKeys, Key key, IntPtr windowHandle)
    {
        Contract.Requires(modifierKeys != ModifierKeys.None || key != System.Windows.Input.Key.None);
        Contract.Requires(windowHandle != IntPtr.Zero);

        Key = key;
        KeyModifier = modifierKeys;
        _id = GetHashCode();
        _handle = windowHandle;
        RegisterHotKey();
        ComponentDispatcher.ThreadPreprocessMessage += ThreadPreprocessMessageMethod;
    }

    ~HotKey()
    {
        Dispose();
    }

    public Key Key { get; private set; }

    public ModifierKeys KeyModifier { get; private set; }

    public void RegisterHotKey()
    {
        if (Key == Key.None)
            return;
        if (_isKeyRegistered)
            UnregisterHotKey();
        _isKeyRegistered = HotKeyWinApi.RegisterHotKey(_handle, _id, KeyModifier, Key);
        if (!_isKeyRegistered)
            throw new ApplicationException("Hotkey already in use");
    }

    public void UnregisterHotKey()
    {
        _isKeyRegistered = !HotKeyWinApi.UnregisterHotKey(_handle, _id);
    }

    public void Dispose()
    {
        ComponentDispatcher.ThreadPreprocessMessage -= ThreadPreprocessMessageMethod;
        UnregisterHotKey();
    }

    private void ThreadPreprocessMessageMethod(ref MSG msg, ref bool handled)
    {
        if (!handled)
        {
            if (msg.message == HotKeyWinApi.WmHotKey
                && (int)(msg.wParam) == _id)
            {
                OnHotKeyPressed();
                handled = true;
            }
        }
    }

    private void OnHotKeyPressed()
    {
        if (HotKeyPressed != null)
            HotKeyPressed(this);
    }
}