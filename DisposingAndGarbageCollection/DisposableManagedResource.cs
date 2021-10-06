using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposingAndGarbageCollection
{
    class DisposableManagedResource : IDisposable
    {
        //pointer to an exrernal unmanaged source this class uses
        private IntPtr handle;

        //other managed resources that this class usses that are disposable
        private Component component = new Component();

        //a tracker to know if the object is disposed or no
        private bool isDisposed = false;

        //ctor
        public DisposableManagedResource(IntPtr handle)
        {
            this.handle = handle;
        }

        //implementation starts
        //a non virtual method only for this type, manually disposing
        public void Dispose()
        {
            Dispose(true);
            //take this object off the finalization queue as it's disposed, no need to finalize  
            GC.SuppressFinalize(this);
        }

        // for derived types from this class, or for this class
        protected virtual void Dispose(bool manualDisposing)
        {
            //if the object is not disposed...
            //this check is done to be able to call Dispose method over and over again
            if(!this.isDisposed)
            {
                //if this method call is with a "true" meaning we want to manually dispose this object
                //then we need to dispose managed resources it has too...
                if (manualDisposing)
                {
                    //dispose managed resources
                    component.Dispose();
                }

                //... now clean the unmanaged (native) resources with appropriate method calls

                //if this method call is with a "false" meaning the finalizer is calling to destruct the object
                //means we just need to destruct the unmanaged resources this object has, as the rest will eventally use their finalizers too
                //only the following code shall execute
                CloseHandle(handle);
                handle = IntPtr.Zero;

                // the disposing is DONE now
                isDisposed = true;
            }
            //if the disposing is laready done, nothing to run
        }

        //a call to the necessary method, kernel call
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);


        //finalization code
        //only runs only if the Dispose() method wasn't called before already
        //as Dispose(supressed GC as it is said the object is already disposed fully)
        ~DisposableManagedResource()
        {
            Dispose(false);
        }
    }
}
