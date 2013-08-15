Localization4WPF
================

A simple localization extension for WPF.

**Nuget**

http://www.nuget.org/packages/Localization4WPF/

**Sample**

```xml
<Window x:Class="DemoApplication.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:loc4wpf="http://schemas.denkberg.com/Localization4WPF/"
        Title="MainWindow" Height="350" Width="525">
    <Window.Resources>
        <loc4wpf:LocalizationConverter x:Key="LocalizationConverter"/>
    </Window.Resources>
    <Grid>
        <!-- Using Markup Extension -->
        <TextBlock Text="{loc4wpf:LocalizeString Key=MY_KEY}"/>
        
        <!-- Using a Converter (The BindedText is actually the Key of the resource string)-->
        <TextBlock Text="{Binding Path=BindedText, Converter={StaticResource LocalizationConverter}}"/>
    </Grid>
</Window>

```
