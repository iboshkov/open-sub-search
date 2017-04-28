using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OpenSubSearchLib
{
    public class HashUtils
    {

        public static byte[] calculateMD5(Stream stream, Action<float> progressReportAction = null)
        {
            MD5CryptoServiceProvider md5prov = new MD5CryptoServiceProvider();
            long offset = 0;
            int size = 2000000; // 1 MB chunks

            Int32 readAmount = 0;
            byte[] input = new byte[size];
            while ((readAmount = stream.Read(input, 0, size)) > 0)
            {
                offset += readAmount;
                md5prov.TransformBlock(input, 0, readAmount, input, 0);
                float progress = (float) offset / stream.Length;

                progressReportAction?.Invoke(progress);
            }

            md5prov.TransformFinalBlock(input, 0, readAmount);
            return md5prov.Hash;
        }
    }
}