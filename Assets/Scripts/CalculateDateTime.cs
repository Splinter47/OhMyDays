using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CalculateDateTime : MonoBehaviour {

	private TimeSpan timeLeft;
	private double targetTime;
	private string displayString;
	private DateTime targetDateTime;
	private string displayType;

	public GameObject monthObj;
	public GameObject yearObj;

	public int year;
	public int month;
	public int day;
	public int hour;
	public int min;

	public UILabel label;
	public UICenterOnChild centreringGrid;

	//time formats
	List<TimeFormats> formats = new List<TimeFormats>();

	void Start(){
		SetTarget(2014,8,4,17,0);

		formats.Add(new TimeFormats("Seconds", 1.0));
	}

	// Update is called once per frame
	void Update () {

		//find the current time measurement
		//UICenterOnChild

		Calculate();

		if(DateTime.Compare(targetDateTime, DateTime.Now) > 0){
			Display();
		}else{
			label.text = Celebrate();
			label.MarkAsChanged();
		}
	}

	public void SetTarget(int year, int month, int day, int hour, int minute){
		targetDateTime = new DateTime(year, month, day, hour, minute, 0);
		print (targetDateTime);
		print (DateTime.Now);
		timeLeft = (targetDateTime - DateTime.Now);
	}

	private void Calculate(){
		timeLeft = (targetDateTime - DateTime.Now);
	}

	private void Display(){
		displayString = timeLeft.Minutes.ToString();
		label.text = displayString;
		label.MarkAsChanged();
	}

	private string Celebrate(){
		return "France!";
	}

	public void NextTimeFormat(){

	}

	public void PlayMonth(){
		StartCoroutine(SwitchInputs(monthObj, yearObj));
	}

	private IEnumerator SwitchInputs(GameObject obj1, GameObject obj2){

		yield return new WaitForSeconds(0.5f);
		obj1.SetActive(true);

		yield return new WaitForSeconds(0.8f);
		//wait 0.5 secs for month to start
		obj2.SetActive(false);
	}

	private void PlayGroup(int group, bool direction, GameObject target){
		UITweener[] tweens = target.GetComponentsInChildren<UITweener>();
		foreach (UITweener tween in tweens)
		{
			if (tween.tweenGroup == group)
			{
				tween.Play(direction);
			}
		}
	}
}
