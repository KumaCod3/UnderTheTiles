using UnityEngine;

public abstract class baseCarta: MonoBehaviour
{
	public virtual void action()
	{
		Debug.Log("azione di: " + gameObject.name);
	}

	public void disegna(int x, int y)
	{
		Instantiate(gameObject, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0));
		if (gameObject.GetComponent<PopinoController>())
		{
			gameObject.GetComponent<PopinoController>().setXY(x, y);
		}
	}
}
