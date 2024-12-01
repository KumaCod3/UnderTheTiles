using UnityEngine;
public class Popino: baseCarta
{
	static public Vector3 dir;

	public void Awake()
	{
		//	base.Start();
		nome = "Popino";
		dir = gameObject.transform.position;

		PopinoController.vitta = 2;
		vita = 2;
		attacco = 1;
		if (PopinoLivelli.lancia)
		{
			attacco++;
		}
		punti = GameManager.punti;
	}
	public override void action()
	{
	}
	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, dir, speed * Time.deltaTime);
		if (!GameManager.eInPausa())
		{
			if (PopinoController.vitta <= 0)
			{
				Debug.Log("GAME OVEEEEER!!!!");

				gameObject.GetComponent<GestCarta>().diePop();
				GameManager.pausa();
			}
		}

	}
	public override void ogniTurno()
	{
	}
	public void setDir(int x, int y)
	{
		dir = new Vector3(y, x, -1);
	}
}
