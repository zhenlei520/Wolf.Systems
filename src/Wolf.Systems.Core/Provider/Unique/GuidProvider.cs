// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core.Provider.Unique;

/// <summary>
///
/// </summary>
public class GuidProvider : IGuidGeneratorProvider
{
    /// <summary>
    ///
    /// </summary>
    public int Type => SequentialGuidType.Default.Id;

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public Guid Create() => Guid.NewGuid();
}
