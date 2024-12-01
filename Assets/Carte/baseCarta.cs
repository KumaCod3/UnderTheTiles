using System;
using System.Collections;
using UnityEngine;

public abstract class baseCarta: MonoBehaviour
{
	public string nome;

	public int punti;
	public int vita;
	public int attacco;
	public string nomeSuono;
	protected GameObject _pino;
	public float speed = 1.5f;
	bool onlyOne = true;
	public bool fulminato;
	public virtual void Start()
	{
		_pino = GameObject.FindWithTag("Player");
		fulminato = false;
	}
	public virtual void action()
	{
		FindObjectOfType<AudioManager>().PlaySound(nomeSuono);
	}

	private void LateUpdate()
	{
		if (gameObject.tag.Equals("mostro"))
		{
			//if (vita <= 0 && onlyOne)
			//{
			//	onlyOne = false;
			//	_pino.GetComponent<PopinoController>().camPun(GameManager.punti + punti);
			//	gameObject.GetComponent<GestCarta>().die();
			//	if (BoardManager.scacchiera[(int)gameObject.transform.position.y][(int)gameObject.transform.position.x] == null)
			//	{
			//		BoardManager.metVuot((int)gameObject.transform.position.y, (int)gameObject.transform.position.x);
			//	}
			//	if (PopinoLivelli.vampiro)
			//	{
			//		_pino.GetComponent<PopinoController>().camVita(_pino.GetComponent<PopinoController>().getVita() + 1);
			//	}
			//}
		}
	}
	public abstract void ogniTurno();
	public void disegna(int x, int y)
	{
		GameObject card = Instantiate(gameObject, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0));
		if (gameObject.GetComponent<PopinoController>())
		{
			gameObject.GetComponent<PopinoController>().setXY(y, x);
			card.GetComponent<Popino>().setDir(y, x);
			BoardManager.pop = card;
		}
		else if (gameObject.GetComponent<CartaMostro3>())
		{
			gameObject.GetComponent<CartaMostro3>().setXY(y, x);
			gameObject.GetComponent<CartaMostro3>().setDir(y, x);
			card.transform.parent = GameObject.Find("/Caselle").transform;
		}


		else if (gameObject.GetComponent<Vuota>())
		{
			card.transform.parent = GameObject.Find("/Vuote").transform;
		}
		else
		{
			card.transform.parent = GameObject.Find("/Caselle").transform;
		}
		BoardManager.assegna(card, y, x);
	}

	public void combat(bool tr)
	{
		int vitaMostro = vita;
		int vitapopo = _pino.GetComponent<PopinoController>().getVita();
		while (vitaMostro > 0 && vitapopo > 0)
		{
			if (PopinoLivelli.lancia && !tr)
			{
				colpodietro();
			}
			vitaMostro = vitaMostro - _pino.GetComponent<PopinoController>().getAttacco();
			vitapopo = vitapopo - attacco;
		}

		_pino.GetComponent<PopinoController>().camVita(vitapopo);
		_pino.GetComponent<PopinoController>().camPun(GameManager.punti + punti);
		gameObject.GetComponent<GestCarta>().die();
		if (PopinoLivelli.vampiro && !tr)
		{
			_pino.GetComponent<PopinoController>().camVita(_pino.GetComponent<PopinoController>().getVita() + 1);
		}

	}

	public IEnumerator scivola(Vector3 fin, float vel)
	{
		while (Vector3.Distance(fin, transform.position) > 0.01)
		{
			transform.position = Vector3.MoveTowards(transform.position, fin, vel * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
	}
	public IEnumerator scivolaTorna(Vector3 fin, float vel, Vector3 orig)
	{
		yield return scivola(fin, vel);
		FindObjectOfType<AudioManager>().PlaySound(nomeSuono);
		yield return scivola(orig, vel);
		gameObject.GetComponent<GestCarta>().scura();
	}
	public IEnumerator attk(bool t)
	{
		gameObject.GetComponent<GestCarta>().schiara();
		yield return scivolaTorna(Popino.dir, 7f, transform.position);
		if (t)
		{
			combat(true);
		}
		else
		{
			_pino.GetComponent<PopinoController>().camVita(_pino.GetComponent<PopinoController>().getVita() - attacco);
		}
	}
	public void togli1()
	{
		vita--;
		gameObject.GetComponent<GestCarta>().cambia1("" + vita, true);
		if (vita <= 0 && onlyOne)
		{
			onlyOne = false;
			BoardManager.metVuot((int)gameObject.transform.position.y, (int)gameObject.transform.position.x);
			_pino.GetComponent<PopinoController>().camPun(GameManager.punti + punti);
			gameObject.GetComponent<GestCarta>().die();
		}
	}

	public void colpodietro()
	{
		int x = -1;
		int y = -1;
		if (gameObject.transform.position.x == _pino.transform.position.x)
		{
			x = (int)gameObject.transform.position.x;
			int diff = (int)gameObject.transform.position.y - (int)_pino.transform.position.y;
			y = (int)gameObject.transform.position.y + diff;
		}
		else if (gameObject.transform.position.y == _pino.transform.position.y)
		{
			y = (int)gameObject.transform.position.y;
			int diff = (int)gameObject.transform.position.x - (int)_pino.transform.position.x;
			x = (int)gameObject.transform.position.x + diff;

		}
		baseCarta dietro = null;
		try
		{
			dietro = BoardManager.scacchiera[y][x].GetComponent<baseCarta>();
		}
		catch (Exception e) { }
		if (dietro != null && dietro.gameObject.tag.Equals("mostro"))
		{
			dietro.togli1();
		}

	}
}
