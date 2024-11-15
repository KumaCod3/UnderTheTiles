using UnityEngine;
public class CartaUscita: baseCarta
{
	public int costoUscita;

	private void Start()
	{
		gameObject.GetComponent<GestCarta>().cambia4("-" + costoUscita);
		tipo = "movimento";
		nome = "Uscita";
		descrizione = "Per vincere il livello, vieni qui.";
	}

	private void Update()
	{
	}
	public override void action()
	{
		base.action();
		Debug.Log("WINN ");
	}

}
