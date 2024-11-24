public class CartaBonus1: baseCarta
{
	private void Start()
	{
		base.Start();
		gameObject.GetComponent<GestCarta>().cambia2("+" + attacco);
		gameObject.GetComponent<GestCarta>().cambia4("+" + punti);
		nome = "Pozione Attacco";
	}


	public override void action()
	{
		base.action();
		_pino.GetComponent<PopinoController>().camAtta(_pino.GetComponent<PopinoController>().getAttacco() + attacco);
		_pino.GetComponent<PopinoController>().camPun(GameManager.punti + punti);
		gameObject.GetComponent<GestCarta>().bevi();
	}
	public override void ogniTurno()
	{
	}
}
