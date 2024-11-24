public class CartaMostro4: baseCarta
{

	private void Start()
	{
		base.Start();
		nome = "Mostro 4";
	}

	public override void action()
	{
		base.action();
		combat();
	}
	public override void ogniTurno()
	{

	}
}
