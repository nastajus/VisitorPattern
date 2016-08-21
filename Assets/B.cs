using UnityEngine;
using System.Collections;

//suppose "B" is the "Vehicle" which receives the attack, and only receives from "A" (Zombie)
public class B : Thing {

	bool isColliding = false;  

	//do nothing, particularly, do not call AcceptDamageFrom at all
	protected override void OnCollisionEnter(Collision col)
	{
		if (isColliding) return;
		isColliding = true;

		print("B OnCollisionEnter executing... does nothing");
	}

	void OnCollisionExit(Collision col)
	{
		isColliding = false;
	}
}
