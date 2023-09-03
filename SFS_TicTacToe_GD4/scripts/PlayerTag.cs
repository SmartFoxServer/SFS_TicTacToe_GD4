using Godot;

public partial class PlayerTag : Control
{
    [ExportCategory("UI Settings")]

    [Export] public Label label;
    [Export] public Label playerName;
    [Export] public Label winsValue;
    [Export] public TextureButton addBuddyButton;

    private int wins;

    public int Wins
    {
        get => wins;

        set
        {
            wins = value;

            // Update wins label
            winsValue.Text = "Wins: " + wins;

            // Show/hide wins label
            if (wins > 0)
                winsValue.Show();
        }
    }
}
