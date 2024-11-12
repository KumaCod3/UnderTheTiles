using TMPro;
using UnityEngine;

public class InGameManager: MonoBehaviour
{
	void Start()
	{
	}

	void Update()
	{
	}
	public void setDesc(string tip, string nom, string des)
	{
		gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(tip);
		gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().SetText(nom);
		gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().SetText(des);
	}
}
