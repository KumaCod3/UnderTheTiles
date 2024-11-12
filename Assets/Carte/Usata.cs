public class Usata: baseCarta
{
	public int costo;
	private void Start()
	{
		gameObject.GetComponent<GestCarta>().cambia4("-" + costo);
		tipo = "movimento";
		nome = "Vuota";
		descrizione = "Passare da qui ti costa un movimento.";
	}
	public override void action()
	{
		base.action();
		GameManager.punti -= 1;
	}
}
