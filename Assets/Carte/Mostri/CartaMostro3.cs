public class CartaMostro3: baseCarta
{
	public int punti;
	public int vita;
	public int attacco;

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

		while (vita > 0 && PopinoController.vita > 0)
		{
			vita = vita - PopinoController.attacco;
			PopinoController.vita = PopinoController.vita - attacco;
		}
		if (vita <= 0)
		{
			GameManager.punti = GameManager.punti + punti;
			Destroy(gameObject);
		}
	}
	public override void ogniTurno()
	{
		PopinoController.vita = PopinoController.vita - attacco;
	}
}
