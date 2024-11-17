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
	Animator anum;

	void Start()
	{
		TS = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
		BS = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
		TD = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
		BD = gameObject.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
		anim = gameObject.GetComponent<Animator>();
		anum = gameObject.GetComponentInChildren<Animator>();
	}

	public void cambia1(string s)
	{
		StartCoroutine(cambiaA(s));
	}
	public void cambia2(string s)
	{
		StartCoroutine(cambiaB(s));
	}
	public void cambia3(string s)
	{
		StartCoroutine(cambiaC(s));
	}
	public void cambia4(string s)
	{
		StartCoroutine(cambiaD(s));
	}
	private IEnumerator cambiaA(string s)
	{
		anum.SetTrigger("vita");
		yield return new WaitForSeconds(.1f);
		TS.SetText(s);
	}

	private IEnumerator cambiaB(string s)
	{
		anum.SetTrigger("attacco");
		yield return new WaitForSeconds(.1f);
		TD.SetText(s);
	}
	private IEnumerator cambiaC(string s)
	{
		anum.SetTrigger("vita");
		yield return new WaitForSeconds(.1f);
		BS.SetText(s);
	}
	private IEnumerator cambiaD(string s)
	{
		anum.SetTrigger("uscita");
		yield return new WaitForSeconds(.1f);
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
