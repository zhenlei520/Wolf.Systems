// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Data.Provider.Unique
{
    /// <summary>
    ///
    /// </summary>
    public class SequentialAsBinaryProvider : IGuidGeneratorProvider
    {
        /// <summary>
        ///
        /// </summary>
        private static readonly RandomNumberGenerator RandomNumberGenerator = RandomNumberGenerator.Create();

        /// <summary>
        /// 类型
        /// </summary>
        public int Type => SequentialGuidType.SequentialAsBinary.Id;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Guid Create()
        {
            // We start with 16 bytes of cryptographically strong random data.
            var randomBytes = new byte[10];
            RandomNumberGenerator.GetBytes(randomBytes);

            long timestamp = DateTime.UtcNow.Ticks / 10000L;

            // Then get the bytes
            byte[] timestampBytes = BitConverter.GetBytes(timestamp);

            // Since we're converting from an Int64, we have to reverse on
            // little-endian systems.
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(timestampBytes);
            }

            byte[] guidBytes = new byte[16];

            // For string and byte-array version, we copy the timestamp first, followed
            // by the random data.
            Buffer.BlockCopy(timestampBytes, 2, guidBytes, 0, 6);
            Buffer.BlockCopy(randomBytes, 0, guidBytes, 6, 10);

            return new Guid(guidBytes);
        }
    }
}
