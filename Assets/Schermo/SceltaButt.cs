using UnityEngine;
using UnityEngine.UI;

public class SceltaButt: MonoBehaviour
{
	public void higgg()
	{
		gameObject.GetComponent<Image>().color = new Color(0.28f, 0.28f, 0.28f, .8f);
	}

	public void spent()
	{
		gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1);
	}
}
