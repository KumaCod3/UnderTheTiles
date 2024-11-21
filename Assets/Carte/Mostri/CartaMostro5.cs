public class CartaMostro5: baseCarta
{

	private void Start()
	{
		base.Start();
		tipo = "nemico";
		nome = "Mostro 5";
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
