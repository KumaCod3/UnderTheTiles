public class Usata: baseCarta
{
	public int costo;
	private void Start()
	{
		gameObject.GetComponent<GestCarta>().cambia4("-" + costo);
	}
	public override void action()
	{
		base.action();
		GameManager.punti -= 1;
	}
}
