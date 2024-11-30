using UnityEngine;
public class Popino: baseCarta
{
	Vector3 dir;

	public void Awake()
	{
		//	base.Start();
		nome = "Popino";
		dir = gameObject.transform.position;

		PopinoController.vitta = 2;
		vita = 2;
		attacco = 1;
		punti = GameManager.punti;
		//		gameObject.GetComponent<GestCarta>().cambia1("" + _pino.GetComponent<PopinoController>().getVita(), false);
		//		gameObject.GetComponent<GestCarta>().cambia2("" + _pino.GetComponent<PopinoController>().getAttacco(), false);
		//		gameObject.GetComponent<GestCarta>().cambia4("" + GameManager.punti, false);
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
				Debug.Log("GAME OVEEEEER!!!! pop");

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
