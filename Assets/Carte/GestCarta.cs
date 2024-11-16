using TMPro;
using UnityEngine;

public class GestCarta: MonoBehaviour
{
	TextMeshProUGUI TS;
	TextMeshProUGUI BS;
	TextMeshProUGUI TD;
	TextMeshProUGUI BD;
	Animator anim;

	void Start()
	{
		TS = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
		BS = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
		TD = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
		BD = gameObject.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
		anim = gameObject.GetComponent<Animator>();
	}

	public void cambia1(string s)
	{
		TS.SetText(s);
	}
	public void cambia2(string s)
	{
		TD.SetText(s);
	}
	public void cambia3(string s)
	{
		BS.SetText(s);
	}
	public void cambia4(string s)
	{
		BD.SetText(s);
	}
	public void wiggle()
	{

		//	gameObject.GetComponent<Animator>()
		anim.SetTrigger("Attacca");
	}
}
