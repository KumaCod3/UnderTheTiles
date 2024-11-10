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
	public void setDesc(string des)
	{
		gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(des);
	}
}
