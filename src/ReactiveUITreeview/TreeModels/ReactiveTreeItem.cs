﻿// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CP.Reactive;
using ReactiveUI;

namespace ReactiveUITreeview;

/// <summary>
/// Reactive Tree Item.
/// </summary>
/// <seealso cref="ReactiveObject" />
public abstract class ReactiveTreeItem : ReactiveObject
{
    private ReactiveTreeItem? _parent;
    private bool _isExpanded;
    private bool _isSelected;

    /// <summary>
    /// Initializes a new instance of the <see cref="ReactiveTreeItem"/> class.
    /// </summary>
    /// <param name="children">The children.</param>
    protected ReactiveTreeItem(IEnumerable<ReactiveTreeItem>? children = null)
    {
        Children = new();
        if (children == null)
        {
            return;
        }

        foreach (var child in children)
        {
            AddChild(child);
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is expanded.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is expanded; otherwise, <c>false</c>.
    /// </value>
    public bool IsExpanded
    {
        get => _isExpanded;
        set => this.RaiseAndSetIfChanged(ref _isExpanded, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is selected.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is selected; otherwise, <c>false</c>.
    /// </value>
    public bool IsSelected
    {
        get => _isSelected;
        set => this.RaiseAndSetIfChanged(ref _isSelected, value);
    }

    /// <summary>
    /// Gets the view model.
    /// </summary>
    /// <value>
    /// The view model.
    /// </value>
    public abstract object ViewModel { get; }
    /// <summary>
    /// Gets the children.
    /// </summary>
    /// <value>
    /// The children.
    /// </value>
    public ReactiveList<ReactiveTreeItem> Children { get; }

    /// <summary>
    /// Adds the child.
    /// </summary>
    /// <param name="child">The child.</param>
    public void AddChild(ReactiveTreeItem child)
    {
        ArgumentNullException.ThrowIfNull(child);
        child._parent = this;
        Children.Add(child);
    }

    /// <summary>
    /// Removes the selected child and its children.
    /// </summary>
    public void RemoveChild() => _parent?.Children.Remove(this);

    /// <summary>
    /// Expands the path.
    /// </summary>
    public void ExpandPath()
    {
        IsExpanded = true;
        _parent?.ExpandPath();
    }

    /// <summary>
    /// Collapses the path.
    /// </summary>
    public void CollapsePath()
    {
        IsExpanded = false;
        _parent?.CollapsePath();
    }
}
