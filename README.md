# Populating WPF Wizard Control by Data Binding
This example demonstrates how to populate the Syncfusion WPF WizardControl using data binding techniques in a WPF application. The WizardControl is a powerful UI component that enables developers to create step-by-step navigation interfaces, commonly used in installation wizards, onboarding flows, and multi-step forms.

## Overview
Instead of hardcoding wizard pages, this approach dynamically generates and populates them by binding a collection of data objects to the control. This makes the design flexible, scalable, and easier to maintain—ideal for applications where wizard steps depend on user input or external data.

## Key Features
- **Data Model for Wizard Steps:** Each step is represented by a model class.
- **Dynamic Binding:** Bind a collection of models to the WizardControl.
- **Custom Templates:** Use styles and data templates to customize appearance.
- **Navigation Logic:** Manage navigation programmatically based on bound data.

## Implemenation Example

### XAML
```XAML
<Window.DataContext>
    <local:ViewModel/>
</Window.DataContext>

<Window.Resources>
    <Style x:Key="WizardPageStyle" TargetType="syncfusion:WizardPage">
        <Setter Property="Title" Value="{Binding Title}"/>
        <Setter Property="PageType" Value="Exterior"/>
        <Setter Property="BannerImage" Value="/Images/W_O-BG.png"/>
    </Style>
</Window.Resources>

<Grid>
    <syncfusion:WizardControl x:Name="wizardcontrol"
                               ItemContainerStyle="{StaticResource WizardPageStyle}"
                               ItemsSource="{Binding PageItems}">
        <syncfusion:WizardControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Content}" TextWrapping="Wrap"/>
            </DataTemplate>
        </syncfusion:WizardControl.ItemTemplate>
    </syncfusion:WizardControl>
</Grid>
```

### ViewModel and Model Classes (C#)
```C#
public class ViewModel : NotificationObject
{
    private ObservableCollection<Model> pageitems;
    public ObservableCollection<Model> PageItems
    {
        get => pageitems;
        set
        {
            pageitems = value;
            RaisePropertyChanged("PageItems");
        }
    }

    public ViewModel()
    {
        pageitems = new ObservableCollection<Model>();
        PopulatePageItems();
    }

    private void PopulatePageItems()
    {
        pageitems.Add(new Model { Title = "XML Developer's Guide", Content = "An in-depth look at creating applications with XML." });
        pageitems.Add(new Model { Title = "Midnight Rain", Content = "A former architect battles corporate zombies and an evil sorceress." });
        pageitems.Add(new Model { Title = "Oberon's Legacy", Content = "In post-apocalypse England, Oberon helps rebuild life in London." });
        pageitems.Add(new Model { Title = "Lover Birds", Content = "When Carla meets Paul at an ornithology conference, feathers fly." });
        pageitems.Add(new Model { Title = "Science Fiction", Content = "James Salway discovers the problems of being quantum." });
    }
}

public class Model : NotificationObject
{
    private string title;
    public string Title
    {
        get => title;
        set
        {
            title = value;
            RaisePropertyChanged("Title");
        }
    }

    private string content;
    public string Content
    {
        get => content;
        set
        {
            content = value;
            RaisePropertyChanged("Content");
        }
    }
}
```

## How It Works
- ItemsSource binds the WizardControl to PageItems in the ViewModel.
- Each Model represents a wizard step with Title and Content.
- The ItemTemplate defines how each step’s content is displayed.
- Styles customize the wizard page appearance dynamically.
