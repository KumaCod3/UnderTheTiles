public class CartaMostro5: baseCarta
{

	private void Start()
	{
		base.Start();
		nome = "Mostro 5";
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
