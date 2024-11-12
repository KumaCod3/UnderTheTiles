using UnityEngine;
public class CartaUscita: baseCarta
{
	public int costoUscita;

	private void Start()
	{
		gameObject.GetComponent<GestCarta>().cambia3("" + costoUscita);
		tipo = "movimento";
		nome = "Uscita";
		descrizione = "Per vincere il livello, vieni qui.";
	}

	private void Update()
	{
		int residuo = costoUscita - GameManager.punti;
		if (residuo < 0)
		{
			residuo = 0;
		}
		gameObject.GetComponent<GestCarta>().cambia4("" + residuo);
	}
	public override void action()
	{
		base.action();

		Debug.Log("WINN ");

	}

}
