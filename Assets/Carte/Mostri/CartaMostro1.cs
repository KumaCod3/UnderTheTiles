public class CartaMostro1: baseCarta
{

	private void Start()
	{
		base.Start();
		tipo = "nemico";
		nome = "Mostro 1";
		descrizione = "Se mi uccidi guadagi punti.";
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
