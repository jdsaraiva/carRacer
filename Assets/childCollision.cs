using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childCollision : MonoBehaviour {
	
	void OnTriggerEnter (Collider other) {		
		gameObject.SendMessageUpwards("collision", gameObject.name);
	}	
}
