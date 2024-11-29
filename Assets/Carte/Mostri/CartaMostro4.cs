public class CartaMostro4: baseCarta
{

	public override void Start()
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
		_pino.GetComponent<PopinoController>().camVita(_pino.GetComponent<PopinoController>().getVita() - attacco);
		base.action();
	}
}
