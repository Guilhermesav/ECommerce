﻿using Azure.Storage.Blobs;
using ECommerce.Model.Interfaces.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ECommerce.Blob
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;
        private readonly BlobContainerClient _containerClient;

        private const string ContainerAzure = "ecommerceinfnetblob";
        public BlobService(string storageAccount)
        {
            _blobClient = new BlobServiceClient(storageAccount);

            _containerClient = _blobClient.GetBlobContainerClient(ContainerAzure);
        }

       
        public async Task<string> CreateBlobAsync(string imageBase64)
        {
            var stream = new MemoryStream(Convert.FromBase64String(imageBase64));

            if (!await _containerClient.ExistsAsync())
            {
                await _containerClient.CreateIfNotExistsAsync();
                await _containerClient.SetAccessPolicyAsync(global::Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
            }

            var blobClient = _containerClient.GetBlobClient($"{Guid.NewGuid()}.jpg");


            await blobClient.UploadAsync(stream, true);

            return blobClient.Uri.ToString();
        }

        public async Task DeleteBlobAsync(string blobName)
        {
            var blob = new BlobClient(new Uri(blobName));

            var blobClient = _containerClient.GetBlobClient(blob.Name);

            await blobClient.DeleteIfExistsAsync();
        }
    }
}
