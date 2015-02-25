using UnityEngine;
using System.Collections;

public class YearOnPress : MonoBehaviour {

	public int year;
	public CalculateDateTime calculator;

	void Start(){
		calculator = GameObject.Find("LabelController").GetComponent<CalculateDateTime>();
	}

	public void OnClick(){
		calculator.year = year;
	}
}
