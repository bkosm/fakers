using System;
using System.ComponentModel;

namespace DisposableElement
{
    public abstract class Disposable : IDisposable
    {
        IntPtr _handle;
        Component _component = new Component();
        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {

                if (disposing)
                {
                    _component.Dispose();
                }

                CloseHandle(_handle);
                _handle = IntPtr.Zero;

                _disposed = true;
            }
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

    }
}
