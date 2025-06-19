// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CrissCross.WPF.UI.Controls;

namespace ReactiveUITreeview;

/// <summary>
/// Person.
/// </summary>
/// <seealso cref="ReactiveTreeItem" />
public class Person
    : ReactiveTreeItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Person"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="children">The children.</param>
    public Person(string? name, IEnumerable<ReactiveTreeItem>? children = null)
        : base(children) => DisplayName = name;

    /// <summary>
    /// Gets the view model.
    /// </summary>
    /// <value>
    /// The view model.
    /// </value>
    public override object ViewModel => this;
}
