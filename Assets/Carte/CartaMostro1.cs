public class CartaMostro1: baseCarta
{
	public int punti;
	public int vita;
	public int attacco;
	public override void action()
	{
		base.action();
		//while (vita > 0 && PopinoController.vita > 0)
		//{
		//	vita = vita - PopinoController.attacco;
		//	PopinoController.vita = PopinoController.vita - attacco;
		//}
		//if (vita <= 0)
		//{
		//	GameManager.punti = GameManager.punti + punti;
		//	Debug.Log("mostro battuto");
		//	Destroy(gameObject);
		//}
	}
}
