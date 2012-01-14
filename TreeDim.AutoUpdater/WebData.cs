#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Net;
#endregion

namespace TreeDim.AutoUpdater
{
    class WebData
    {
        public static event BytesDownloadedEventHandler bytesDownloaded;

        public static bool downloadFromWeb(string URL, string file, string targetFolder)
        {
            try
            {
                byte[] downloadedData = new byte[0];

                // open a data stream from the supplied URL
                WebRequest webReq = WebRequest.Create(URL + file);
                webReq.Credentials = CredentialCache.DefaultCredentials;
                WebResponse webResponse = webReq.GetResponse();
                Stream dataStream = webResponse.GetResponseStream();

                // download the data in chuncks
                byte[] dataBuffer = new byte[1024];

                // get the total size of the download
                int dataLength = (int)webResponse.ContentLength;

                // lets declare our downloaded bytes event args
                ByteArgs byteArgs = new ByteArgs();

                byteArgs.downloaded = 0;
                byteArgs.total = dataLength;

                // we need to test for a null as if an event is not consumed we will get an exception
                if (bytesDownloaded != null)
                    bytesDownloaded(byteArgs);


                // download the data
                MemoryStream memoryStream = new MemoryStream();
                while (true)
                {
                    // let's try and read the data
                    int bytesFromStream = dataStream.Read(dataBuffer, 0, dataBuffer.Length);

                    if (bytesFromStream == 0)
                    {

                        byteArgs.downloaded = dataLength;
                        byteArgs.total = dataLength;
                        if (bytesDownloaded != null) bytesDownloaded(byteArgs);

                        // download complete
                        break;
                    }
                    else
                    {
                        // write the downloaded data
                        memoryStream.Write(dataBuffer, 0, bytesFromStream);

                        byteArgs.downloaded = bytesFromStream;
                        byteArgs.total = dataLength;
                        if (bytesDownloaded != null) bytesDownloaded(byteArgs);

                    }
                }

                // convert the downloaded stream to a byte array
                downloadedData = memoryStream.ToArray();

                // release resources
                dataStream.Close();
                memoryStream.Close();

                // write bytes to the specified file
                FileStream newFile = new FileStream(Path.Combine(targetFolder, file), FileMode.Create);
                newFile.Write(downloadedData, 0, downloadedData.Length);
                newFile.Close();

                return true;
            }

            catch (Exception /*ex*/)
            {
                // we may not be connected to the internet
                // or the URL may be incorrect
                return false;
            }
        }
    }
    public delegate void BytesDownloadedEventHandler(ByteArgs e);

    public class ByteArgs : EventArgs
    {
        private int _downloaded;
        private int _total;

        public int downloaded
        {
            get { return _downloaded; }
            set { _downloaded = value; }
        }

        public int total
        {
            get { return _total; }
            set { _total = value; }
        }

    }
}
