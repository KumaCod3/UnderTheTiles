public class CartaMostro5: baseCarta
{

	private void Start()
	{
		tipo = "nemico";
		nome = "Mostro 5";
		descrizione = "boooooo";
	}
	private void Update()
	{
		gameObject.GetComponent<GestCarta>().cambia1("" + vita);
		gameObject.GetComponent<GestCarta>().cambia2("" + attacco);
		gameObject.GetComponent<GestCarta>().cambia4("+" + punti);
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
