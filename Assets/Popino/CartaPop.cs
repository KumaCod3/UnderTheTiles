using UnityEngine;
using UnityEngine.UI;

public class CartaPop: GestCarta
{
	Color on = new Color(0, 1, 0, 1);
	Color off = new Color(1, 0, 0, 1);
	GameObject scudo;
	GameObject ali;
	GameObject zanne;
	GameObject lancia;
	GameObject mago;
	GameObject bo;


	public void Start()
	{
		base.Start();
		scudo = gameObject.transform.GetChild(0).GetChild(4).gameObject;
		ali = gameObject.transform.GetChild(0).GetChild(5).gameObject;
		zanne = gameObject.transform.GetChild(0).GetChild(6).gameObject;
		lancia = gameObject.transform.GetChild(0).GetChild(7).gameObject;
		mago = gameObject.transform.GetChild(0).GetChild(8).gameObject;
		bo = gameObject.transform.GetChild(0).GetChild(9).gameObject;
		scudo.SetActive(false);
		ali.SetActive(false);
		zanne.SetActive(false);
		lancia.SetActive(false);
		mago.SetActive(false);
		bo.SetActive(false);
	}

	private void Update()
	{
		for (int i = 0; i < PopinoLivelli.abilita.Count; i++)
		{
			switch (i)
			{
				case 0:
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
					else if (PopinoLivelli.abilita[i] == 2)
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
					break;
				case 1:
					if (PopinoLivelli.abilita[i] == 1)
					{
						zanne.SetActive(true);
					}
					else if (PopinoLivelli.abilita[i] == 2)
					{
						lancia.SetActive(true);
					}
					break;
				case 2:
					if (PopinoLivelli.abilita[i] == 1)
					{
						mago.SetActive(true);
						if (PopinoLivelli.mago)
						{
							mago.GetComponent<Image>().color = on;
						}
						else
						{
							mago.GetComponent<Image>().color = off;
						}
					}
					else if (PopinoLivelli.abilita[i] == 2)
					{
						bo.SetActive(true);
						if (PopinoLivelli.alchimista)
						{
							bo.GetComponent<Image>().color = on;
						}
						else
						{
							bo.GetComponent<Image>().color = off;
						}
					}
					break;
				default:
					break;
			}
		}
	}
}