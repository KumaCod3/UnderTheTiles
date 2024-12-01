using UnityEngine;
using UnityEngine.UI;

public class SceltaButt: MonoBehaviour
{
	Color iniziale;
	private void Start()
	{
		iniziale = gameObject.GetComponent<Image>().color;
	}
	public void higgg()
	{
		gameObject.GetComponent<Image>().color = new Color(0.30f, 0.30f, 0.30f, .9f);
	}

	public void spent()
	{
		gameObject.GetComponent<Image>().color = iniziale;
	}
}
