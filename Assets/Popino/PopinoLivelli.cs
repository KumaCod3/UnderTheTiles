using System.Collections.Generic;
using UnityEngine;

public class PopinoLivelli: MonoBehaviour
{
	public static bool tutorial = true;

	public static bool jump = false;
	public static bool shield = false;

	public static bool bo1;
	public static PopinoLivelli instance;

	public static List<int> abilita;

	public static int[] uscite = { 3, 11, 5 };

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
}

