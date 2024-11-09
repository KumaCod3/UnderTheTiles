public class Usata: baseCarta
{
	public override void action()
	{
		base.action();
		GameManager.punti -= 1;
	}
}
