// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Security.Cryptography;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Data.Enumerations;

namespace Wolf.Systems.Data.Provider.Unique
{
    /// <summary>
    ///
    /// </summary>
    public class SequentialAtEndProvider : IGuidGeneratorProvider
    {
        private static readonly RandomNumberGenerator RandomNumberGenerator = RandomNumberGenerator.Create();

        /// <summary>
        ///
        /// </summary>
        public int Type => SequentialGuidType.SequentialAtEnd.Id;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Guid Create()
        {
            // We start with 16 bytes of cryptographically strong random data.
            var randomBytes = new byte[10];
            RandomNumberGenerator.GetBytes(randomBytes);

            // Using millisecond resolution for our 48-bit timestamp gives us
            // about 5900 years before the timestamp overflows and cycles.
            // Hopefully this should be sufficient for most purposes. :)
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

            // For sequential-at-the-end versions, we copy the random data first,
            // followed by the timestamp.
            Buffer.BlockCopy(randomBytes, 0, guidBytes, 0, 10);
            Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6);

            return new Guid(guidBytes);
        }
    }
}
