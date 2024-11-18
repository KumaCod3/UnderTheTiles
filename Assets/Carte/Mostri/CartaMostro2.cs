public class CartaMostro2: baseCarta
{


	private void Start()
	{
		base.Start();
		tipo = "nemico";
		nome = "Mostro 2";
		descrizione = "Se mi uccidi guadagi punti. Se mi arrivi accanto inizio io la battaglia";
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
