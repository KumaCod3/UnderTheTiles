using UnityEngine;
using UnityEngine.UI;

public class CartaPop: GestCarta
{
	Color on = new Color(0, 1, 0, 1);
	Color off = new Color(1, 0, 0, 1);
	GameObject scudo;
	GameObject ali;


	public void Start()
	{
		base.Start();
		scudo = gameObject.transform.GetChild(0).GetChild(4).gameObject;
		ali = gameObject.transform.GetChild(0).GetChild(5).gameObject;
		scudo.SetActive(false);
		ali.SetActive(false);
	}

	private void Update()
	{
		for (int i = 0; i < PopinoLivelli.abilita.Count; i++)
		{
			if (PopinoLivelli.abilita[i] == 1)
			{
				scudo.SetActive(true);
				if (PopinoLivelli.shield)
				{
					scudo.GetComponent<Image>().color = on;
				}
				else
				{
					scudo.GetComponent<Image>().color = off;
				}
			}
			else
			{
				ali.SetActive(true);
				if (PopinoLivelli.jump)
				{
					ali.GetComponent<Image>().color = on;
				}
				else
				{
					ali.GetComponent<Image>().color = off;
				}
			}
		}
	}
}
