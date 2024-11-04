using UnityEngine;

public abstract class baseCarta: MonoBehaviour
{
	public abstract void action();

	public void disegna(int x, int y)
	{
		Instantiate(gameObject, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0));
	}

}
