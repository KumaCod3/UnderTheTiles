using UnityEngine;

public abstract class baseCarta: MonoBehaviour
{
	public virtual void action()
	{
		Debug.Log("azione di: " + gameObject.name);
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
