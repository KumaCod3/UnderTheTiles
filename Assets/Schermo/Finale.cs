using UnityEngine;

public class Finale: MonoBehaviour
{
	public static int scelta;
	private void Update()
	{
		if (scelta != 0)
		{
			scelto();
		}
	}
	private void Start()
	{
		scelta = 0;
		spegni();
	}

	public void spegni()
	{
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
		gameObject.transform.GetChild(1).gameObject.SetActive(false);
		gameObject.transform.GetChild(2).gameObject.SetActive(false);
	}
	public void SetWin(bool win)
	{
		int at = 0;
		int dis = 0;

		if (win)
			at = 1;
		else
			dis = 1;
		spegni();
		gameObject.transform.GetChild(at).gameObject.SetActive(true);
		gameObject.transform.GetChild(dis).gameObject.SetActive(false);

	}
	public void scelto()
	{
		spegni();
		gameObject.transform.GetChild(2).gameObject.SetActive(true);
		gameObject.transform.GetChild(2).GetChild(scelta).gameObject.SetActive(true);
	}

}
