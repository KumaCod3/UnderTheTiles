using UnityEngine;

public class GameManager: MonoBehaviour
{
	public static int punti;
	public static PopinoController pino;
	public InGameManager _IGM;
	private static bool inPausa = false;
	public GameObject scherFin;
	public GameObject scherTut;
	public static int vinto;


	private void Start()
	{
		scherFin.SetActive(false);
		if (PopinoLivelli.tutorial && scherTut != null)
		{
			scherTut.SetActive(true);
		}
		else if (scherTut != null)
		{
			scherTut.SetActive(false);
			play();
		}
		else
		{
			play();
		}

		punti = 0;
		vinto = 0;
		svuotaDesc();
	}

	private void Update()
	{
		if (!eInPausa())
		{
			if (punti < 0)
			{
				punti = 0;
			}

			Vector3 cor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			int xx = Mathf.RoundToInt(cor.x);
			int yy = Mathf.RoundToInt(cor.y);
			if (BoardManager.checkLim(yy, xx) && BoardManager.sopraCarta(yy, xx).GetComponent<baseCarta>())
			{
				string nom = BoardManager.sopraCarta(yy, xx).GetComponent<baseCarta>().nome;
				_IGM.setDesc(nom);
			}
			else
			{
				svuotaDesc();
			}
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				if (BoardManager.check(yy, xx))
				{
					StartCoroutine(pino.moveToR(yy, xx));
				}
			}
		}
		else if (vinto == 1)
		{
			vito(true);
		}
		else if (vinto == 2)
		{
			vito(false);
		}
	}

	private void svuotaDesc()
	{
		string nom = "";
		_IGM.setDesc(nom);
	}
	public static bool eInPausa()
	{
		return inPausa;
	}
	public static void pausa()
	{
		inPausa = true;
	}
	public static void play()
	{
		inPausa = false;
	}

	public void vito(bool win)
	{

		scherFin.SetActive(true);
		//	scherFin.GetComponent<Finale>().spegni();
		scherFin.GetComponent<Finale>().SetWin(win);
	}


	/*	public void cambiaScema(int x)
		{
			PlayerPrefs.SetInt("attacco", PopinoController.attacco);
			PlayerPrefs.SetInt("vita", PopinoController.vita);
			PlayerPrefs.SetInt("punti", punti);

			SceneManager.LoadScene(x);
		}
		private void carica()
		{
			if (PlayerPrefs.GetInt("attacco") != 0)
				PopinoController.attacco = PlayerPrefs.GetInt("attacco");
			if (PlayerPrefs.GetInt("vita") != 0)
				PopinoController.vita = PlayerPrefs.GetInt("vita");
			punti = PlayerPrefs.GetInt("punti");
		}*/

	public void startAgain()
	{
		int indice = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
		UnityEngine.SceneManagement.SceneManager.LoadScene(indice);
	}
	public void nextt()
	{
		int indice = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
		UnityEngine.SceneManagement.SceneManager.LoadScene(indice + 1);
	}
}
