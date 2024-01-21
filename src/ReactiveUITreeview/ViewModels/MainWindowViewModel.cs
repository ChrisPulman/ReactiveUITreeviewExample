// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Reactive;
using CP.Reactive;
using ReactiveUI;

namespace ReactiveUITreeview;

/// <summary>
/// MainWindowViewModel.
/// </summary>
/// <seealso cref="ReactiveUI.ReactiveObject" />
public class MainWindowViewModel : ReactiveObject
{
    private ReactiveTreeItem? _selectedItem;
    private string? _newName;
    private string? _petName;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    public MainWindowViewModel()
    {
        var cliffordPulman = new Person("Clifford Pulman", new[] { new Pet("Kitty") });
        var clifford = new Person("Clifford", new[] { cliffordPulman });
        var clarencePulman = new Person("Clarence Pulman");
        var clarence = new Person("Clarence", new[] { clarencePulman });
        Family = new ReactiveList<ReactiveTreeItem>([clifford, clarence]);

        AddPerson = ReactiveCommand.Create<object>(_ => { });
        AddPerson.Subscribe(_ =>
        {
            if (SelectedItem == null)
            {
                return;
            }

            var p = new Person(NewName);
            SelectedItem.AddChild(p);
            p.IsSelected = true;
            p.ExpandPath();
        });
        AddPet = ReactiveCommand.Create<object>(_ => { });
        AddPet.Subscribe(_ =>
        {
            if (SelectedItem == null)
            {
                return;
            }

            var p = new Pet(PetName);
            SelectedItem.AddChild(p);
            p.IsSelected = true;
            p.ExpandPath();
        });
        Collapse = ReactiveCommand.Create<object>(_ => { });
        Collapse.Subscribe(_ => SelectedItem?.CollapsePath());
        Expand = ReactiveCommand.Create<object>(_ => { });
        Expand.Subscribe(_ => SelectedItem?.ExpandPath());
    }

    /// <summary>
    /// Gets the family.
    /// </summary>
    /// <value>
    /// The family.
    /// </value>
    public ReactiveList<ReactiveTreeItem> Family { get; }

    /// <summary>
    /// Gets the add person.
    /// </summary>
    /// <value>
    /// The add person.
    /// </value>
    public ReactiveCommand<object, Unit> AddPerson { get; }

    /// <summary>
    /// Gets the add pet.
    /// </summary>
    /// <value>
    /// The add pet.
    /// </value>
    public ReactiveCommand<object, Unit> AddPet { get; }

    /// <summary>
    /// Gets the collapse.
    /// </summary>
    /// <value>
    /// The collapse.
    /// </value>
    public ReactiveCommand<object, Unit> Collapse { get; }

    /// <summary>
    /// Gets the expand.
    /// </summary>
    /// <value>
    /// The expand.
    /// </value>
    public ReactiveCommand<object, Unit> Expand { get; }

    /// <summary>
    /// Gets or sets creates new name.
    /// </summary>
    /// <value>
    /// The new name.
    /// </value>
    public string? NewName
    {
        get => _newName;
        set => this.RaiseAndSetIfChanged(ref _newName, value);
    }

    /// <summary>
    /// Gets or sets the name of the pet.
    /// </summary>
    /// <value>
    /// The name of the pet.
    /// </value>
    public string? PetName
    {
        get => _petName;
        set => this.RaiseAndSetIfChanged(ref _petName, value);
    }

    /// <summary>
    /// Gets or sets the selected item.
    /// </summary>
    /// <value>
    /// The selected item.
    /// </value>
    public ReactiveTreeItem? SelectedItem
    {
        get => _selectedItem;
        set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
    }
}
