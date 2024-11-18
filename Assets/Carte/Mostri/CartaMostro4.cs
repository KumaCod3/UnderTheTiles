public class CartaMostro4: baseCarta
{

	private void Start()
	{
		base.Start();
		tipo = "nemico";
		nome = "Mostro 4";
		descrizione = "Se mi uccidi guadagi punti. Ad ogni turno mi avvicino e se adiacente attacco";
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
