using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Model.Interfaces.Blob
{
    public interface IBlobService
    {
        Task<string> CreateBlobAsync(string imageBase64);
        Task DeleteBlobAsync(string blobName);
    }
}
