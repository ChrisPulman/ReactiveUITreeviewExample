// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CrissCross.WPF.UI.Controls;

namespace ReactiveUITreeview;

/// <summary>
/// Pet.
/// </summary>
/// <seealso cref="ReactiveTreeItem" />
public class Pet : ReactiveTreeItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Pet"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public Pet(string? name) => DisplayName = name;

    /// <summary>
    /// Gets the view model.
    /// </summary>
    /// <value>
    /// The view model.
    /// </value>
    public override object ViewModel => this;
}
