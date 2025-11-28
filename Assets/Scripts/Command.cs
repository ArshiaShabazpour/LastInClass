using UnityEngine;

public interface ICommand
{
    void Execute(PlayerCar actor);
}

public class MoveLeftCommand : ICommand
{
    public void Execute(PlayerCar actor) => actor.SetMoveLeft(true);
}

public class StopMoveLeftCommand : ICommand
{
    public void Execute(PlayerCar actor) => actor.SetMoveLeft(false);
}

public class MoveRightCommand : ICommand
{
    public void Execute(PlayerCar actor) => actor.SetMoveRight(true);
}

public class StopMoveRightCommand : ICommand
{
    public void Execute(PlayerCar actor) => actor.SetMoveRight(false);
}
