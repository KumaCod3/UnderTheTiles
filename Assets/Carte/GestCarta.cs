using System.Collections;
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
		anim.SetTrigger("Attacca");
	}
	public void die()
	{
		anim.SetBool("Morto", true);
	}
	public void diePop()
	{
		StartCoroutine(specEmuori());
	}
	private IEnumerator specEmuori()
	{
		yield return new WaitForSeconds(.2f);
		anim.SetBool("Morto", true);
	}
	public void bevi()
	{
		anim.SetBool("Bevi", true);
	}
	public void dist()
	{
		Destroy(gameObject);
	}
	public void esciPop()
	{
		anim.SetBool("EsciPop", true);
	}
	public void esciPorta()
	{
		anim.SetBool("EsciPort", true);
	}
}
