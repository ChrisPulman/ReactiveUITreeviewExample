// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Windows;
using ReactiveUI;

namespace ReactiveUITreeview;

/// <summary>
/// Interaction logic for PersonView.xaml.
/// </summary>
public partial class PersonView : IViewFor<Person>
{
    /// <summary>
    /// The view model property.
    /// </summary>
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
        nameof(ViewModel), typeof(Person), typeof(PersonView), new PropertyMetadata(default(Person)));

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonView"/> class.
    /// </summary>
    public PersonView()
    {
        InitializeComponent();
        this.OneWayBind(ViewModel, vm => vm.Name, v => v.PersonName.Text);
    }

    /// <summary>
    /// Gets or sets the ViewModel corresponding to this specific View. This should be
    /// a DependencyProperty if you're using XAML.
    /// </summary>
    object? IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = (Person?)value;
    }

    /// <summary>
    /// Gets or sets the ViewModel corresponding to this specific View. This should be
    /// a DependencyProperty if you're using XAML.
    /// </summary>
    public Person? ViewModel
    {
        get => (Person?)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }
}
