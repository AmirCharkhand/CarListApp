using CarListApp.Controls;

namespace CarListApp.Models
{
    public class FlyoutMenuModel(FlyoutHeader flyoutHeader, List<ShellContent> contents)
    {
        public FlyoutHeader FlyoutHeader { get; init; } = flyoutHeader;
        public List<ShellContent> Contents { get; init; } = contents;
    }
}
