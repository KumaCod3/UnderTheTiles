public class CartaBonus2: baseCarta
{

	private void Start()
	{
		base.Start();
		gameObject.GetComponent<GestCarta>().cambia1("+" + vita);
		gameObject.GetComponent<GestCarta>().cambia4("" + punti);
		tipo = "bonus";
		nome = "Pozione Vita";
		descrizione = "Guadagni 2 punto vita e 1 punto movimento.";
	}

	public override void action()
	{
		base.action();
		_pino.GetComponent<PopinoController>().camVita(_pino.GetComponent<PopinoController>().getVita() + vita);
		_pino.GetComponent<PopinoController>().camPun(GameManager.punti + punti);
		gameObject.GetComponent<GestCarta>().bevi();
		gameObject.GetComponent<GestCarta>().muori();
	}
	public override void ogniTurno()
	{
	}
}
