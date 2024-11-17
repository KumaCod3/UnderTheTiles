using UnityEngine;

public abstract class baseCarta: MonoBehaviour
{
	public string tipo;
	public string nome;
	public string descrizione;

	public int punti;
	public int vita;
	public int attacco;
	public virtual void action()
	{
	}

	public abstract void ogniTurno();
	public virtual void disegna(int x, int y)
	{
		GameObject card = Instantiate(gameObject, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0), GameObject.Find("/Caselle").transform);
		if (gameObject.GetComponent<PopinoController>())
		{
			gameObject.GetComponent<PopinoController>().setXY(x, y);
		}
		BoardManager.assegna(card, y, x);
	}

	public void combat()
	{
		while (vita > 0 && PopinoController.vita > 0)
		{
			vita = vita - PopinoController.attacco;
			PopinoController.vita = PopinoController.vita - attacco;
		}
		if (vita <= 0)
		{
			GameManager.punti = GameManager.punti + punti;
			gameObject.GetComponent<GestCarta>().die();
		}
	}
}
