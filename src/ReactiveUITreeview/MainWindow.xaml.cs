// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;
using Splat;

namespace ReactiveUITreeview;

/// <summary>
/// Interaction logic for MainWindow.xaml.
/// </summary>
public partial class MainWindow : IViewFor<MainWindowViewModel>
{
    /// <summary>
    /// The view model property.
    /// </summary>
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
        nameof(ViewModel), typeof(MainWindowViewModel), typeof(MainWindow), new PropertyMetadata(default(MainWindowViewModel)));

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

        // create viewmodel
        ViewModel = new();

        // Register treeview elements
        Locator.CurrentMutable.Register(() => new PersonView(), typeof(IViewFor<Person>));
        Locator.CurrentMutable.Register(() => new PetView(), typeof(IViewFor<Pet>));

        this.WhenActivated(d =>
        {
            // Bind viewmodel to Treeview
            this.OneWayBind(ViewModel, vm => vm.Family, v => v.FamilyTree.ViewModel!.Children).DisposeWith(d);
            this.WhenAnyValue(x => x.FamilyTree.SelectedItem).BindTo(this, x => x.ViewModel!.SelectedItem).DisposeWith(d);
            this.Bind(ViewModel, vm => vm.NewName, v => v.NewName.Text).DisposeWith(d);
            this.Bind(ViewModel, vm => vm.PetName, v => v.PetName.Text).DisposeWith(d);
            this.Bind(ViewModel, vm => vm.SelectedElement, v => v.Selected.Text).DisposeWith(d);
            this.Bind(ViewModel, vm => vm.LastSelectedElement, v => v.LastSelected.Text).DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.AddPerson, v => v.AddPerson);
            this.BindCommand(ViewModel, vm => vm.AddPet, v => v.AddPet);
            this.BindCommand(ViewModel, vm => vm.Collapse, v => v.Collapse);
            this.BindCommand(ViewModel, vm => vm.Expand, v => v.Expand);
            this.BindCommand(ViewModel, vm => vm.Remove, v => v.Remove);
        });
    }

    /// <summary>
    /// Gets or sets the ViewModel corresponding to this specific View. This should be
    /// a DependencyProperty if you're using XAML.
    /// </summary>
    object? IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = (MainWindowViewModel?)value;
    }

    /// <summary>
    /// Gets or sets the ViewModel corresponding to this specific View. This should be
    /// a DependencyProperty if you're using XAML.
    /// </summary>
    public MainWindowViewModel? ViewModel
    {
        get => (MainWindowViewModel?)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }
}
