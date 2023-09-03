
using Godot;
using System;

public partial class GameBoard : Control
{
    public int row;
    public int col;

    [Export] public Control TicTacToeGameNode;

    [ExportCategory("Board Slots")]


    [Export] public TextureButton Slot1_1;
    [Export] public TextureButton Slot1_2;
    [Export] public TextureButton Slot1_3;
    [Export] public TextureButton Slot2_1;
    [Export] public TextureButton Slot2_2;
    [Export] public TextureButton Slot2_3;
    [Export] public TextureButton Slot3_1;
    [Export] public TextureButton Slot3_2;
    [Export] public TextureButton Slot3_3;

    [ExportCategory("Game Sprites")]

    [Export]
    public Texture2D sprite0;
    [Export]
    public Texture2D sprite1;
    [Export]
    public Texture2D sprite2;

    private Texture2D[] markSprites;
    private TextureButton[,] slots;
    private bool isEnabled;

    public enum Mark
    {
        EMPTY = 0,
        CROSS,
        RING
    };

    private Mark mark = Mark.EMPTY;

    public override void _Ready()
    {
        InitBoard();

        markSprites = new Texture2D[3];
        markSprites[0] = sprite0;
        markSprites[1] = sprite1;
        markSprites[2] = sprite2;

        Slot1_1.Pressed += () => { OnSlotClick(1, 1); };
        Slot1_2.Pressed += () => { OnSlotClick(1, 2); };
        Slot1_3.Pressed += () => { OnSlotClick(1, 3); };
        Slot2_1.Pressed += () => { OnSlotClick(2, 1); };
        Slot2_2.Pressed += () => { OnSlotClick(2, 2); };
        Slot2_3.Pressed += () => { OnSlotClick(2, 3); };
        Slot3_1.Pressed += () => { OnSlotClick(3, 1); };
        Slot3_2.Pressed += () => { OnSlotClick(3, 2); };
        Slot3_3.Pressed += () => { OnSlotClick(3, 3); };
    }

    public void Reset()
    {
         foreach (TextureButton slot in slots)
            if (slot != null) // Ignore null slots (0-indexes)
            {
                slot.TextureNormal = (Texture2D)markSprites[0];
                slot.TextureDisabled = (Texture2D)markSprites[0];
                slot.Disabled = false;
            }
    }

    public bool IsEnabled
    {
        get => isEnabled;

        set
        {
            isEnabled = value;
        }
    }

    /**
     * Listen to custom click event dispatched by GameBoardSlot instances.
     */

    public void OnSlotClick(int row, int col)

    {
        if (isEnabled)
        {
            // Re-dispatch event
            // GD.Print("clicked " + row + col);
            TicTacToeGameNode.Call("OnBoardSlotClick", row, col);
        }
    }

    public void SetMark(int r, int c, int value)
    {
        slots[r - 1, c - 1].TextureDisabled = (Texture2D)markSprites[value];
        slots[r - 1, c - 1].Disabled = true;
    }

    /**
     * Initialize data structure containing references to GameBoardSlot instances.
     */
    private void InitBoard()
    {
         // We use a two-dimensional array with 4x4 entries, so we can have 1-based indexes for the board 
        slots = new TextureButton[4, 4];

        for (int r = 1; r <= 3; r++)
        {
            for (int c = 1; c <= 3; c++)
            {
                string slotObjName = String.Format("Slot {0}-{1}", r, c);
                slots[r - 1, c - 1] = GetNode<TextureButton>(slotObjName);

            }
        }
    }
}

