using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
	public Camera[] cameras;
	private int cameraIndex;


	void Start () {
		cameraIndex = 0;

		// confirm every camera is off except for the first one, that's why the 1 value in i integer 
		for (int index=1; index<cameras.Length; index++) 
			cameras[index].gameObject.SetActive(false);
		
	}
		
	void Update () {
		
		// When the player presses TAB the camera will switch, TAB is a key easy to find even of you have the headset on
		// we are going to disable the current active camera and enable the following camera according to the index of the array
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			cameraIndex ++;

			Debug.Log ("Switch camera");

			if (cameraIndex < cameras.Length)
			{
				cameras[cameraIndex-1].gameObject.SetActive(false);
				cameras[cameraIndex].gameObject.SetActive(true);

				Debug.Log ("Camera " + cameras [cameraIndex].GetComponent<Camera>().name + ", activated");

			}
			// If there are no more cameras at the array index it's  because we have reached the limit and 
			// will go back to the first camera 
			else
			{
				cameras[cameraIndex-1].gameObject.SetActive(false);
				cameraIndex = 0;
				cameras[cameraIndex].gameObject.SetActive(true);

				Debug.Log ("Camera " + cameras [cameraIndex].GetComponent<Camera>().name + ", activated");
			}
		}
	}
}