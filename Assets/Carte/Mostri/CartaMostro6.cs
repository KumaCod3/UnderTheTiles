public class CartaMostro6: baseCarta
{
	public override void Start()
	{
		base.Start();
		nome = "Mostro 6";
	}
	public override void action()
	{
		base.action();
		combat(false);
	}
	public override void ogniTurno()
	{
	}
}

