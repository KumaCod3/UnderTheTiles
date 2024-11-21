public class CartaMostro6: baseCarta
{
	private void Start()
	{
		base.Start();
		tipo = "nemico";
		nome = "Mostro 6";
		descrizione = "boooooo";
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

