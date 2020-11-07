using Godot;
using System;

public class bat : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    [Export] public int Speed = 10;
    public Vector2 velocity = new Vector2();

    public void GetInput()
    {

        velocity = new Vector2();
        if (Input.IsActionPressed("bar_left")){
            velocity.x = -Speed;
        } else if (Input.IsActionPressed("bar_right"))
        {
            velocity.x = Speed;
        }
        else
        {
            velocity.x = 0;
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame/
    public override void _Process(float delta)
   {
        GetInput();
        var collision = MoveAndCollide(velocity);
        if(collision != null)
        {
            velocity = velocity.Bounce(collision.Normal);
        }
    }
}
