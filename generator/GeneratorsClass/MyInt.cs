using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GeneratorsClass
{
    public class MyInt : IDisposable
    { 
        int [] tab;

        #region IMPELEMEN_IDISPOSABLE
        IntPtr _handle;
        Component _component = new Component();
        bool _disposed = false;
        #endregion

        public MyInt(int size)
        {
            Tab = new int[size];
        }

        public int[] Tab { get => tab; set => tab = value; }
      
        #region DISPOSE
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
        #endregion

        ~MyInt()
        {
            Dispose(false);
        }

    }
}
