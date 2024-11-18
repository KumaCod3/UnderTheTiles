public class Usata: baseCarta
{
	private void Start()
	{
		base.Start();
		tipo = "movimento";
		nome = "Vuota";
		descrizione = "Passare da qui ti costa un movimento.";
	}
	public override void action()
	{
		base.action();
		_pino.GetComponent<PopinoController>().camPun(GameManager.punti - punti);
	}
	public override void ogniTurno()
	{
	}
}
