// Copyright (c) Chris Pulman. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Reactive;
using System.Reactive.Linq;
using CP.Reactive;
using CrissCross.WPF.UI.Controls;
using ReactiveUI;

namespace ReactiveUITreeview;

/// <summary>
/// MainWindowViewModel.
/// </summary>
/// <seealso cref="ReactiveObject" />
public class MainWindowViewModel : ReactiveObject
{
    private ReactiveTreeItem? _selectedItem;
    private string? _newName;
    private string? _petName;
    private string? _selectedElement;
    private string? _lastSelectedElement;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    public MainWindowViewModel()
    {
        var cliffordPulman = new Person("Clifford Pulman", [new Pet("Kitty")]);
        var clifford = new Person("Clifford", [cliffordPulman]);
        var clarencePulman = new Person("Clarence Pulman");
        var clarence = new Person("Clarence", [clarencePulman]);
        Family = new ReactiveList<ReactiveTreeItem>([clifford, clarence]);

        AddPerson = ReactiveCommand.Create(() => { });
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
        AddPet = ReactiveCommand.Create(() => { });
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
        Collapse = ReactiveCommand.Create(() => { });
        Collapse.Subscribe(_ => SelectedItem?.CollapsePath());
        Expand = ReactiveCommand.Create(() => { });
        Expand.Subscribe(_ => SelectedItem?.ExpandPath());
        Remove = ReactiveCommand.Create(() => { });
        Remove.Subscribe(_ => SelectedItem?.RemoveChild());
        var isAnimalOrPerson = Family.CurrentItems.FlattenAndSelect(
            rti =>
            {
                if (rti is Person person)
                {
                    return rti.WhenAnyValue(vs => vs.IsSelected).Select(x => (x, person.DisplayName));
                }
                else if (rti is Pet pet)
                {
                    return rti.WhenAnyValue(vs => vs.IsSelected).Select(x => (x, pet.DisplayName));
                }
                else
                {
                    return rti.WhenAnyValue(vs => vs.IsSelected).Select(x => (x, (string?)"NoName"));
                }
            });
        isAnimalOrPerson.Subscribe(x =>
        {
            if (x.x)
            {
                SelectedElement = x.Item2;
            }
            else
            {
                LastSelectedElement = x.Item2;
            }
        });
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
    public ReactiveCommand<Unit, Unit> AddPerson { get; }

    /// <summary>
    /// Gets the add pet.
    /// </summary>
    /// <value>
    /// The add pet.
    /// </value>
    public ReactiveCommand<Unit, Unit> AddPet { get; }

    /// <summary>
    /// Gets the remove.
    /// </summary>
    /// <value>
    /// The remove.
    /// </value>
    public ReactiveCommand<Unit, Unit> Remove { get; }

    /// <summary>
    /// Gets the collapse.
    /// </summary>
    /// <value>
    /// The collapse.
    /// </value>
    public ReactiveCommand<Unit, Unit> Collapse { get; }

    /// <summary>
    /// Gets the expand.
    /// </summary>
    /// <value>
    /// The expand.
    /// </value>
    public ReactiveCommand<Unit, Unit> Expand { get; }

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
    /// Gets or sets the selected element.
    /// </summary>
    /// <value>
    /// The selected element.
    /// </value>
    public string? SelectedElement
    {
        get => _selectedElement;
        set => this.RaiseAndSetIfChanged(ref _selectedElement, value);
    }

    /// <summary>
    /// Gets or sets the last selected element.
    /// </summary>
    /// <value>
    /// The last selected element.
    /// </value>
    public string? LastSelectedElement
    {
        get => _lastSelectedElement;
        set => this.RaiseAndSetIfChanged(ref _lastSelectedElement, value);
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
