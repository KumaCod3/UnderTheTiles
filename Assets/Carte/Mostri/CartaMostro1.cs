public class CartaMostro1: baseCarta
{

	public override void Start()
	{
		base.Start();
		nome = "Mostro 1";
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
