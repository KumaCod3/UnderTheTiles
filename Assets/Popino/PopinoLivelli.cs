using System.Collections.Generic;
using UnityEngine;

public class PopinoLivelli: MonoBehaviour
{
	public static bool tutorial = true;

	public static bool jump = false;
	public static bool shield = false;

	public static bool vampiro = false;
	public static bool lancia = false;



	public static PopinoLivelli instance;
	public static List<int> abilita;

	public static int[] uscite = { 3, 11, 20 };

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

		abilita.Add(1);
		abilita.Add(2);


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
		//	shield = true;
		Finale.scelta = 1;
		abilita.Add(1);
	}
	public static void scelta6()
	{
		//	jump = true;
		Finale.scelta = 2;
		abilita.Add(2);
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
						//	shield = true;
					}
					else if (abilita[i] == 2)
					{
						//	jump = true;
					}
					break;
				default:
					break;
			}
		}
	}
}

