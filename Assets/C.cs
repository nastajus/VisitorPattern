using UnityEngine;
using System.Collections;

public class C : Thing {

	bool isColliding = false; // required to limit multiple executions for a single OnCollisionEnter to once per instance

	//do nothing, particularly, do not call AcceptDamageFrom at all
	protected override void OnCollisionEnter(Collision col)
	{
		if (isColliding) return;
		isColliding = true;

		print("A OnCollisionEnter executing... does nothing");
	}

	void OnCollisionExit(Collision col)
	{
		isColliding = false;
	}
}
