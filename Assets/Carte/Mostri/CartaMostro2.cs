public class CartaMostro2: baseCarta
{


	private void Start()
	{
		base.Start();
		nome = "Mostro 2";
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
