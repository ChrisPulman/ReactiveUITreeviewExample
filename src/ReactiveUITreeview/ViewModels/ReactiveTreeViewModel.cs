// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CP.Reactive;
using ReactiveUI;

namespace ReactiveUITreeview
{
    /// <summary>
    /// ReactiveTreeViewModel.
    /// </summary>
    /// <seealso cref="ReactiveUI.ReactiveObject" />
    public class ReactiveTreeViewModel : ReactiveObject
    {
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public ReactiveList<ReactiveTreeItem> Children { get; set; } = new();
    }
}
