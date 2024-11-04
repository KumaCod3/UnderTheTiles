using UnityEngine;

public class CameraController: MonoBehaviour
{
	public GameManager _gm;
	int zz = -10;
	public float standSize = 4;
	public float zoomSize = 8;


	void Start()
	{
		gameObject.GetComponent<Camera>().orthographicSize = standSize;
	}

	void Update()
	{
		transform.position = new Vector3(_gm.posX, _gm.posY, zz);
		//	gameObject.GetComponent<Camera>().orthographicSize = zoomSize;

	}
}
