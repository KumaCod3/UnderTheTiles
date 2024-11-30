using UnityEngine;
public class CartaUscita: baseCarta
{
	bool test;
	public override void Start()
	{
		base.Start();
		test = true;
		punti = PopinoLivelli.uscite[PopinoLivelli.abilita.Count];
		gameObject.GetComponent<GestCarta>().cambia4("-" + punti, false);
		nome = "Uscita";
	}

	private void Update()
	{
		if (test)
		{
			punti = PopinoLivelli.uscite[PopinoLivelli.abilita.Count];
			gameObject.GetComponent<GestCarta>().cambia4("-" + punti, false);
			test = false;
		}
	}
	public override void action()
	{
		base.action();
		Debug.Log("WINN ");
		gameObject.GetComponent<GestCarta>().esciPorta();
		GameManager.vinto = 1;
		GameManager.pausa();

	}
	public override void ogniTurno()
	{
	}
}
