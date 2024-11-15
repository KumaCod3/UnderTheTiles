using UnityEngine;

public class TutorialScript: MonoBehaviour
{
	int indx;

	void Start()
	{
		indx = 6;
		GameManager.pausa();
	}

	public void segue()
	{
		gameObject.transform.GetChild(indx).gameObject.SetActive(false);
		indx--;
	}
	public void inizia()
	{
		gameObject.transform.GetChild(indx).gameObject.SetActive(false);
		GameManager.play();
		gameObject.SetActive(false);
	}
}
