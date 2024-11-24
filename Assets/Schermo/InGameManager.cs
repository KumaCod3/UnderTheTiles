using UnityEngine;
using UnityEngine.UI;

public class InGameManager: MonoBehaviour
{
	void Start()
	{
	}

	void Update()
	{
	}
	public void setDesc(string nom)
	{
		gameObject.transform.GetChild(0).GetComponent<Image>().sprite = (gameObject.GetComponent<Descrizioni>().getSp(nom));
		/*		gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().SetText(nom);
				gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().SetText(des);*/
	}
}
