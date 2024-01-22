// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ReactiveUITreeview;

/// <summary>
/// Pet.
/// </summary>
/// <seealso cref="ReactiveTreeItem" />
public class Pet(string? name) : ReactiveTreeItem
{
    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string? Name { get; } = name;

    /// <summary>
    /// Gets the view model.
    /// </summary>
    /// <value>
    /// The view model.
    /// </value>
    public override object ViewModel => this;
}
