using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public Text timerLabel; 
	private float time;
	private bool timerActivated;

	// wait for child messages
	void collision(string objectName) {
		
		if (objectName == "start")
			timerActivated = true;
		if (objectName == "finish")
			timerActivated = false;
	}

	void Update() {

		if (timerActivated) {		
			time += Time.deltaTime;
			timerLabel.text = Time.time.ToString ("0.0");
		} 
		if (!timerActivated)
			time = 0;
 
	}
}