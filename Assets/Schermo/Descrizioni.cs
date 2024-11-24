using UnityEngine;

public class Descrizioni: MonoBehaviour
{
	public Descrizione[] elenco;


	public Sprite getSp(string nome)
	{
		foreach (Descrizione d in elenco)
		{
			if (d.nome.Equals(nome))
			{
				return d.immagine;
			}
		}
		return null;
	}
}
