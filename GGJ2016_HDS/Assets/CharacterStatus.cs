using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CharacterStatus : MonoBehaviour {

	public int Max;
	public int Low;
	private GameObject egg;

	public enum Name{
		Chicken,Chick,Pig
	}
	public Name nametype;

	void Update(){
	}
}