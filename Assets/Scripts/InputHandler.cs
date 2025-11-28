using UnityEngine;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour
{
    public PlayerCar playerCar; 

    private Dictionary<KeyCode, ICommand> _keyDownCommands;
    private Dictionary<KeyCode, ICommand> _keyUpCommands;

    private bool _useWASD = false;

    void Start()
    {
        SetupControlsArrows();
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleControls();
        }

        HandleInput(_keyDownCommands, true);
        HandleInput(_keyUpCommands, false);
    }

    void HandleInput(Dictionary<KeyCode, ICommand> bindings, bool isKeyDown)
    {
        foreach (var kvp in bindings)
        {
            if (isKeyDown ? Input.GetKeyDown(kvp.Key) : Input.GetKeyUp(kvp.Key))
            {
                kvp.Value.Execute(playerCar);
            }
        }
    }


    public void ToggleControls()
    {
        _useWASD = !_useWASD;
        if (_useWASD) SetupControlsWASD();
        else SetupControlsArrows();

        Debug.Log($"Controls Remapped. Using WASD: {_useWASD}");
    }

    void SetupControlsArrows()
    {
        _keyDownCommands = new Dictionary<KeyCode, ICommand>
        {
            { KeyCode.LeftArrow, new MoveLeftCommand() },
            { KeyCode.RightArrow, new MoveRightCommand() }
        };

        _keyUpCommands = new Dictionary<KeyCode, ICommand>
        {
            { KeyCode.LeftArrow, new StopMoveLeftCommand() },
            { KeyCode.RightArrow, new StopMoveRightCommand() }
        };
    }

    void SetupControlsWASD()
    {
        _keyDownCommands = new Dictionary<KeyCode, ICommand>
        {
            { KeyCode.A, new MoveLeftCommand() },
            { KeyCode.D, new MoveRightCommand() }
        };

        _keyUpCommands = new Dictionary<KeyCode, ICommand>
        {
            { KeyCode.A, new StopMoveLeftCommand() },
            { KeyCode.D, new StopMoveRightCommand() }
        };
    }
}