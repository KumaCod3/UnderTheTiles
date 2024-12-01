using System.Collections.Generic;
using UnityEngine;

public class PopinoLivelli: MonoBehaviour
{
	public static bool tutorial = true;

	public static bool jump = false;
	public static bool shield = false;

	public static bool vampiro = false;
	public static bool lancia = false;

	public static bool mago = false;
	public static bool alchimista = false;


	public static PopinoLivelli instance;
	public static List<int> abilita;

	public static int[] uscite = { 3, 11, 24, 30 };

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			abilita = new List<int>();
		}
		else
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);

		//if (abilita.Count == 0)
		//{
		//	abilita.Add(2);
		//	abilita.Add(2);
		//	abilita.Add(2);
		//}
		resettAbilita();
	}

	public void cheat()
	{
		if (abilita.Count == 0)
		{
			abilita.Add(2);
			abilita.Add(2);
			abilita.Add(2);
		}
		resettAbilita();
	}

	public static void scelta1()
	{
		shield = true;
		Finale.scelta = 1;
		abilita.Add(1);
	}
	public static void scelta2()
	{
		jump = true;
		Finale.scelta = 2;
		abilita.Add(2);
	}

	public static void scelta3()
	{
		vampiro = true;
		Finale.scelta = 1;
		abilita.Add(1);
	}
	public static void scelta4()
	{
		lancia = true;
		Finale.scelta = 2;
		abilita.Add(2);
	}

	public static void scelta5()
	{
		mago = true;
		Finale.scelta = 1;
		abilita.Add(1);
	}
	public static void scelta6()
	{
		alchimista = true;
		Finale.scelta = 2;
		abilita.Add(2);
	}
	public static void sceltaFIN()
	{
		Finale.scelta = 1;
	}
	public static void winTutto()
	{
		Finale.scelta = 1;
	}

	void resettAbilita()
	{
		for (int i = 0; i < abilita.Count; i++)
		{
			switch (i)
			{
				case 0:
					if (abilita[i] == 1)
					{
						shield = true;
					}
					else if (abilita[i] == 2)
					{
						jump = true;
					}
					break;
				case 1:
					if (abilita[i] == 1)
					{
						vampiro = true;
					}
					else if (abilita[i] == 2)
					{
						lancia = true;
					}
					break;
				case 2:
					if (abilita[i] == 1)
					{
						mago = true;
					}
					else if (abilita[i] == 2)
					{
						alchimista = true;
					}
					break;
				default:
					break;
			}
		}
	}

	public static List<string> descrizFin()
	{
		List<string> lista = new List<string>();

		for (int i = 0; i < abilita.Count; i++)
		{
			switch (i)
			{
				case 0:
					if (abilita[i] == 1)
					{
						lista.Add("Warrior");
					}
					else if (abilita[i] == 2)
					{
						lista.Add("Angel");
					}
					break;
				case 1:
					if (abilita[i] == 1)
					{
						lista.Add("Vampire");
					}
					else if (abilita[i] == 2)
					{
						lista.Add("Archaeologist");
					}
					break;
				case 2:
					if (abilita[i] == 1)
					{
						lista.Add("Mage");
					}
					else if (abilita[i] == 2)
					{
						lista.Add("Alchemist");
					}
					break;
				default:
					break;
			}
		}

		return lista;
	}
}

