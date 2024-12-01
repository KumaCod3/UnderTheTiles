public class CartaMostro5: baseCarta
{

	public override void Start()
	{
		base.Start();
		nome = "Mostro 5";
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
