using UnityEngine;

public class CameraController: MonoBehaviour
{

	public int zoomVal;
	private float due = 1;
	private float tre = 1.5f;
	private float quattro = 2;
	private float cinque = 2.5f;
	private float sei = 3;
	private float sette = 3.5f;

	private void Update()
	{
		if (zoomVal != BoardManager.zom)
		{
			zoomVal = BoardManager.zom;
			checkSize();
		}
	}

	private void checkSize()
	{
		switch (zoomVal)
		{
			case 2:
				zoomIn(due);
				break;
			case 3:
				zoomIn(tre);
				break;
			case 4:
				zoomIn(quattro);
				break;
			case 5:
				zoomIn(cinque);
				break;
			case 6:
				zoomIn(sei);
				break;
			case 7:
				zoomIn(sette);
				break;
		}
	}

	public void zoomIn(float size)
	{
		gameObject.GetComponent<Camera>().orthographicSize = size;
		gameObject.transform.position = new Vector3(size - 0.5f, size - 0.5f, -10);
	}
}
