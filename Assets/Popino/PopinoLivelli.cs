using UnityEngine;

public class PopinoLivelli: MonoBehaviour
{
	public static bool tutorial = true;

	public static bool jump = false;
	public static bool shield = false;

	public static bool bo1;
	public static PopinoLivelli instance;



	void Awake()
	{
		if (instance == null)
		{
			instance = this;
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
	}
	public static void scelta2()
	{
		jump = true;
		Finale.scelta = 2;
	}
}

