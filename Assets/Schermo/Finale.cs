using UnityEngine;

public class Finale: MonoBehaviour
{
	private void OnEnable()
	{
		//		spegni();
	}
	private void Start()
	{
		spegni();
	}

	public void spegni()
	{
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
		gameObject.transform.GetChild(1).gameObject.SetActive(false);
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
}
