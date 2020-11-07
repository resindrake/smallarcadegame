using Godot;
using System;

public class ball : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Save Start Position for Easy Reset?
    }
    [Export] public int Speed = 10;
    public Vector2 velocity = new Vector2();
    bool hasStarted = false;
    public void DoBounce()
    {

    }

    public void GetInput()
    {
        if (!hasStarted)
        {
            if (Input.IsActionPressed("ui_down"))
            {
                //Start the Ball downwards
                velocity.y = Speed;
                hasStarted = !hasStarted;
            }
        }

    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        GetInput();
        var collision = MoveAndCollide(velocity);
        if (collision != null)
        {
            velocity = velocity.Bounce(collision.Normal);
            //Bounces off the walls!
        }
    }
}
