using UnityEngine;
using UnityEngine.UI;

public class InGameManager: MonoBehaviour
{
	public void setDesc(string nom)
	{
		gameObject.transform.GetChild(0).GetComponent<Image>().sprite = gameObject.GetComponent<Descrizioni>().getSp(nom);
	}
}
