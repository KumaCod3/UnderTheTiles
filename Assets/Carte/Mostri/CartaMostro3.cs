public class CartaMostro3: baseCarta
{

	private void Start()
	{
		base.Start();
		tipo = "nemico";
		nome = "Mostro 3";
		descrizione = "Se mi uccidi guadagi punti. Ad ogni turno ti attacco da lontano";
	}

	public override void action()
	{
		base.action();

		combat();
	}
	public override void ogniTurno()
	{
		_pino.GetComponent<PopinoController>().camVita(_pino.GetComponent<PopinoController>().getVita() - attacco);
	}
}
