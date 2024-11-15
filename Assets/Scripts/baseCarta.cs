using UnityEngine;

public abstract class baseCarta: MonoBehaviour
{
	public string tipo;
	public string nome;
	public string descrizione;
	public virtual void action()
	{
	}

	public virtual void disegna(int x, int y)
	{
		GameObject card = Instantiate(gameObject, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0), GameObject.Find("/Caselle").transform);
		if (gameObject.GetComponent<PopinoController>())
		{
			gameObject.GetComponent<PopinoController>().setXY(x, y);
		}
		BoardManager.assegna(card, y, x);
	}
}
