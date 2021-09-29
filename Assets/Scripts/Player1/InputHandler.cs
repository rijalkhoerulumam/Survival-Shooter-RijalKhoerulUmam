using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerShooting1 playerShooting;

    Queue<Command1> commands1 = new Queue<Command1>();

    void FixedUpdate()
    {
        Command1 moveCommand = InputMovementHandling();
        if (moveCommand != null)
        {
            commands1.Enqueue(moveCommand);
            moveCommand.Execute();
        }
    }

    void Update()
    {
        Command1 shootCommand = InputShootHandling();
        if (shootCommand != null)
        {
            shootCommand.Execute();
        }
    }

    Command1 InputMovementHandling()
    {
        if (Input.GetKey(KeyCode.D))
        {
            return new MoveCommand(playerMovement, 1, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            return new MoveCommand(playerMovement, -1, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            return new MoveCommand(playerMovement, 0, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            return new MoveCommand(playerMovement, 0, -1);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            return Undo();
        }
        else
        {
            return new MoveCommand(playerMovement, 0, 0); ;
        }
    }

    Command1 Undo()
    {
        if (commands1.Count > 0)
        {
            Command1 undoCommand = commands1.Dequeue();
            undoCommand.UnExecute();
        }
        return null;
    }

    Command1 InputShootHandling()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            return new ShootCommand(playerShooting);
        }
        else
        {
            return null;
        }
    }
}
