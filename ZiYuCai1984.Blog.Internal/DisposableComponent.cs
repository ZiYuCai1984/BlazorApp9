using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Components;

namespace ZiYuCai1984.Blog.Internal
{
    public abstract class DisposableComponent : ComponentBase, IDisposable
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Debug.Assert(!this.IsDisposed);

            this.InternalDispose();
            this.IsDisposed = true;
        }

        // ReSharper disable once VirtualMemberNeverOverridden.Global
        public virtual void InternalDispose()
        {
        }
    }
}