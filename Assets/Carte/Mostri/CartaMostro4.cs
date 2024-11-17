public class CartaMostro4: baseCarta
{

	private void Start()
	{
		tipo = "nemico";
		nome = "Mostro 4";
		descrizione = "Se mi uccidi guadagi punti. Ad ogni turno mi avvicino e se adiacente attacco";
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
