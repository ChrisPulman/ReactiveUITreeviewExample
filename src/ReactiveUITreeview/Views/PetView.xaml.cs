// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;

namespace ReactiveUITreeview;

/// <summary>
/// Interaction logic for PetView.xaml.
/// </summary>
public partial class PetView : IViewFor<Pet>
{
    /// <summary>
    /// The view model property.
    /// </summary>
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
        nameof(ViewModel), typeof(Pet), typeof(PetView), new PropertyMetadata(default(Pet)));

    /// <summary>
    /// Initializes a new instance of the <see cref="PetView"/> class.
    /// </summary>
    public PetView()
    {
        InitializeComponent();
        this.WhenActivated(d => this.OneWayBind(ViewModel, vm => vm.Name, v => v.PetName.Text).DisposeWith(d));
    }

    /// <summary>
    /// Gets or sets the ViewModel corresponding to this specific View. This should be
    /// a DependencyProperty if you're using XAML.
    /// </summary>
    object? IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = (Pet?)value;
    }

    /// <summary>
    /// Gets or sets the ViewModel corresponding to this specific View. This should be
    /// a DependencyProperty if you're using XAML.
    /// </summary>
    public Pet? ViewModel
    {
        get => (Pet?)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }
}
