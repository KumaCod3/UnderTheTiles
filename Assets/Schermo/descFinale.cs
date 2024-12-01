using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class descFinale: MonoBehaviour
{
	public TextMeshProUGUI testo;

	private void OnEnable()
	{
		List<string> lista = PopinoLivelli.descrizFin();
		string s = "So you finally found out, you were a mighty " + lista[0] + ", that at some point in his life choose to become a " + lista[1] + ".  But there was more in you... You studied hard, and finally became a " + lista[2] + " !!!";
		testo.SetText(s);
	}
}
