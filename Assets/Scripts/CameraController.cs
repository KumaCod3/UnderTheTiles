using UnityEngine;

public class CameraController: MonoBehaviour
{
	public float standSize = 4;
	public float zoomSize = 8;

	public void zoomIn()
	{
		gameObject.GetComponent<Camera>().orthographicSize = standSize;
	}
	public void zoomOut()
	{
		gameObject.GetComponent<Camera>().orthographicSize = zoomSize;
	}
}
