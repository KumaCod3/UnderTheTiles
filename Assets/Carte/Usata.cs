public class Usata: baseCarta
{
	public override void Start()
	{
		base.Start();
		nome = "Vuota";
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
