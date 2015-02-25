using UnityEngine;
using System.Collections;

public class SwipeTime : MonoBehaviour {

	CalculateDateTime calculator;

	void Update(){
		
		Vector2 delta = UICamera.currentTouch.totalDelta;

		print(delta.x + ", " + delta.y);
	}
}
