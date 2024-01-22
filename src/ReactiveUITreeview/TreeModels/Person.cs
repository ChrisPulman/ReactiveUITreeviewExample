// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ReactiveUITreeview;

/// <summary>
/// Person.
/// </summary>
/// <seealso cref="ReactiveTreeItem" />
public class Person(string? name, IEnumerable<ReactiveTreeItem>? children = null)
    : ReactiveTreeItem(children)
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string? Name { get; set; } = name;

    /// <summary>
    /// Gets the view model.
    /// </summary>
    /// <value>
    /// The view model.
    /// </value>
    public override object ViewModel => this;
}
