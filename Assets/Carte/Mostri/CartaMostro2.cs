public class CartaMostro2: baseCarta
{


	public override void Start()
	{
		base.Start();
		nome = "Mostro 2";
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
