using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
namespace WebBankCRUD.Client.Helpers
{
    public static class IJSRuntimeExtensions
    {
        public static ValueTask SaveAs(this IJSRuntime js, string fileName,byte[] content)
        {
            return js.InvokeVoidAsync("saveAsFile", fileName, Convert.ToBase64String(content));
        }
    }
}
