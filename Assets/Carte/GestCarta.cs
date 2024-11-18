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
		if (gameObject.GetComponent<baseCarta>().vita != 0)
			TS.SetText("" + gameObject.GetComponent<baseCarta>().vita);
		else
			TS.SetText("");
		BS = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
		BS.SetText("");
		TD = gameObject.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
		if (gameObject.GetComponent<baseCarta>().attacco != 0)
			TD.SetText("" + gameObject.GetComponent<baseCarta>().attacco);
		else
			TD.SetText("");
		BD = gameObject.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
		if (gameObject.GetComponent<baseCarta>().punti != 0)
			BD.SetText("-" + gameObject.GetComponent<baseCarta>().punti);
		else
			BD.SetText("");
		anim = gameObject.GetComponent<Animator>();
		anum = gameObject.transform.GetChild(0).GetComponent<Animator>();

	}

	public void cambia1(string s)
	{
		StartCoroutine(cambia("vita", s, TS));
	}
	public void cambia2(string s)
	{
		StartCoroutine(cambia("attacco", s, TD));
	}
	public void cambia3(string s)
	{
		// aaaa
	}
	public void cambia4(string s)
	{
		StartCoroutine(cambia("uscita", s, BD));
	}

	private IEnumerator cambia(string par, string val, TextMeshProUGUI tex)
	{
		anum.SetTrigger(par);
		yield return new WaitForSeconds(.2f);
		tex.SetText(val);
	}

	//public void wiggle()
	//{
	//	anim.SetTrigger("Attacca");
	//}
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
		muori();
		anim.SetBool("Morto", true);
	}
	public void muori()
	{
		anum.SetTrigger("muori");
	}
	public void bevi()
	{
		anim.SetBool("Bevi", true);
	}
	public void dist()
	{
		Destroy(gameObject);
	}
	public void disatt()
	{
		gameObject.SetActive(false);
	}
	public void esciPop()
	{
		muori();
		anim.SetBool("EsciPop", true);
	}
	public void esciPorta()
	{
		muori();
		anim.SetBool("EsciPort", true);
		anum.SetTrigger("uscita");
	}
}
