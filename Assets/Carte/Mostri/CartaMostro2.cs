public class CartaMostro2: baseCarta
{


	private void Start()
	{
		tipo = "nemico";
		nome = "Mostro 2";
		descrizione = "Se mi uccidi guadagi punti. Se mi arrivi accanto inizio io la battaglia";
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
		gameObject.GetComponent<GestCarta>().wiggle();
		combat();
	}
	public override void ogniTurno()
	{
	}
}
