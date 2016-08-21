using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class C : Thing {

	// required to limit multiple executions for a single OnCollisionEnter to once per instance
	private List<GameObject> isColliding = new List<GameObject>();

	//do nothing, particularly, do not call AcceptDamageFrom at all
	protected override void OnCollisionEnter(Collision col)
	{
		if (isColliding.Contains(col.gameObject)) return;
		isColliding.Add(col.gameObject);

		print("A OnCollisionEnter executing... does nothing");
	}

	protected override void OnCollisionExit(Collision col)
	{
		isColliding.Remove(col.gameObject);
	}
}
