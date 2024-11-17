public class CartaMostro3: baseCarta
{

	private void Start()
	{
		tipo = "nemico";
		nome = "Mostro 3";
		descrizione = "Se mi uccidi guadagi punti. Ad ogni turno ti attacco da lontano";
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
		PopinoController.vita = PopinoController.vita - attacco;
		gameObject.GetComponent<GestCarta>().wiggle();
	}
}
