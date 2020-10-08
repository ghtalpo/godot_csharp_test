using Godot;
using System.Threading.Tasks;

public class Base : Node2D
{
	[Signal]
	delegate void MySignal1(string willSendsAString); // type checking does not works in here
	[Signal]
	delegate void MySignal2(string willSendsAString); // type checking does not works in here

	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Label myLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		myLabel = GetNode<Label>("Label");
		myLabel.Text = "press start button";
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//
	//  }
	private void _on_Button_pressed()
	{
		// Replace with function body.
		GD.Print("Button1");
		EmitSignal("MySignal1", 1);
	}


	private void _on_Button2_pressed()
	{
		// Replace with function body.
		GD.Print("Button2");
		EmitSignal("MySignal2", "abc");
	}

	private async void _on_Button3_pressed()
	{
		// Replace with function body.
		GD.Print("B3-1");
		myLabel.Text = "waiting for button1";
		await loop_do_something();
		GD.Print("B3-1");
		myLabel.Text = "loop is dead";
	}

	private async Task<int> loop_do_something()
	{
		GD.Print("loop1-1 (waiting for signal1)");
		var a = await ToSignal(this, "MySignal1");
		GD.Print($"ret1-1:{a[0]} {a[0].GetType()}");
		myLabel.Text = "waiting for button2";
		GD.Print("loop1-2 (waiting for signal2)");
		var b = await ToSignal(this, "MySignal2");
		GD.Print($"ret1-2:{b[0]} {b[0].GetType()}");
		GD.Print("loop1-3");
		return 1;
	}

	private int testFunction(int a)
	{
		return a + 1;
	}
}




