public class CartaBonus2: baseCarta
{

	private void Start()
	{
		gameObject.GetComponent<GestCarta>().cambia1("+" + vita);
		gameObject.GetComponent<GestCarta>().cambia4("+1");
		tipo = "bonus";
		nome = "Pozione Vita";
		descrizione = "Guadagni 2 punto vita e 1 punto movimento.";
	}

	public override void action()
	{
		base.action();
		PopinoController.vita += vita;
		GameManager.punti += 1;
		gameObject.GetComponent<GestCarta>().bevi();
	}
	public override void ogniTurno()
	{
	}
}
