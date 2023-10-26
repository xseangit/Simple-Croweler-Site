using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System.Reflection;

namespace ir.news.xsean
{

    public class arvanuplod
    {
        private static IAmazonS3 _s3Client;

        private const string BUCKET_NAME = "newsir";
        private static string LOCAL_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        public static async Task Main(string path, string id)
        {
            string bucketName = BUCKET_NAME;
            string keyName = id;
            var fileinfo = new FileInfo(path);
            string filePath = fileinfo.FullName;

            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials("00242e0d-dbc8-48cf-b7ad-74f062a567ef", "b819753433788031ec909905748ba7fba4d62c3cfa07237ba233fc11e98addc8");
            var config = new AmazonS3Config { ServiceURL = "https://s3.ir-tbz-sh1.arvanstorage.ir" };
            _s3Client = new AmazonS3Client(awsCredentials, config);

            Console.WriteLine("Uploading an object...");
            await UploadObjectAsync(_s3Client, bucketName, keyName, filePath);
        }

        /// <summary>
        /// Uses the low-level API to upload an object from the local system to
        /// to an S3 bucket.
        /// </summary>
        /// <param name="client">The initialized S3 client object used to
        /// perform the multi-part upload.</param>
        /// <param name="bucketName">>The name of the bucket to which to upload
        /// the file.</param>
        /// <param name="keyName">The file name to be used in the
        /// destination S3 bucket.</param>
        /// <param name="filePath">The path, including the file name of the
        /// file to be uploaded to the S3 bucket.</param>
        public static async Task UploadObjectAsync(
            IAmazonS3 client,
            string bucketName,
            string objectName,
            string filePath)
        {
            try
            {
                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectName,
                    FilePath = filePath,
                    ContentType = "text/plain"
                    ,
                    CannedACL = S3CannedACL.PublicRead

                };

                putRequest.Metadata.Add("x-amz-meta-title", "someTitle");

                PutObjectResponse response = await client.PutObjectAsync(putRequest);

                foreach (PropertyInfo prop in response.GetType().GetProperties())
                {
                    Console.WriteLine($"{prop.Name}: {prop.GetValue(response, null)}");
                }

                Console.WriteLine($"Object {objectName} added to {bucketName} bucket");
                File.Delete(filePath);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        /// <summary>
        /// Handles the UploadProgress even to display the progress of the
        /// S3 multi-part upload.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event parameters.</param>
        public static void UploadPartProgressEventCallback(object sender, StreamTransferProgressArgs e)
        {
            Console.WriteLine($"{e.TransferredBytes}/{e.TotalBytes}");
        }
    }
}
