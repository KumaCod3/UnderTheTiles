using UnityEngine;

public class TutorialScript: MonoBehaviour
{
	int indx;

	void Start()
	{
		indx = gameObject.transform.childCount - 1;
		GameManager.pausa();
	}

	public void segue()
	{
		gameObject.transform.GetChild(indx).gameObject.SetActive(false);
		indx--;
		FindObjectOfType<AudioManager>().PlaySound("click");

	}
	public void inizia()
	{
		FindObjectOfType<AudioManager>().PlaySound("click");
		gameObject.transform.GetChild(indx).gameObject.SetActive(false);
		GameManager.play();

		FindObjectOfType<AudioManager>().StopSound("intro");
		FindObjectOfType<AudioManager>().cambiaTema();
		gameObject.SetActive(false);
		PopinoLivelli.tutorial = false;
	}
}
