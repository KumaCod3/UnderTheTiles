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
	public virtual void Start()
	{
		_pino = GameObject.FindWithTag("Player");
	}
	public virtual void action()
	{
		FindObjectOfType<AudioManager>().PlaySound(nomeSuono);
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

	public void combat()
	{
		while (vita > 0 && _pino.GetComponent<PopinoController>().getVita() > 0)
		{
			vita = vita - _pino.GetComponent<PopinoController>().getAttacco();
			_pino.GetComponent<PopinoController>().camVita(_pino.GetComponent<PopinoController>().getVita() - attacco);
		}
		if (vita <= 0)
		{
			_pino.GetComponent<PopinoController>().camPun(GameManager.punti + punti);
			gameObject.GetComponent<GestCarta>().die();
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

			combat();
		}
		else
		{
			_pino.GetComponent<PopinoController>().camVita(_pino.GetComponent<PopinoController>().getVita() - attacco);
		}
	}

}
