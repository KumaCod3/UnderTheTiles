using UnityEngine;

public class TutorialScript: MonoBehaviour
{
	int indx;

	void Start()
	{
		indx = 6;
	}

	public void segue()
	{
		gameObject.transform.GetChild(indx).gameObject.SetActive(false);
		indx--;
	}
	public void inizia()
	{
		gameObject.transform.GetChild(indx).gameObject.SetActive(false);
		GameManager.pausa = false;
		gameObject.SetActive(false);
	}
}
