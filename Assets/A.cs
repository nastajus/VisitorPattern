using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//suppose "A" is the "Zombie" which is attacking, and that "A" can only attack "B".
public class A : Thing {

	// required to limit multiple executions for a single OnCollisionEnter to once per instance
	private List<GameObject> isColliding = new List<GameObject>();

	int damage = 3;


	//do nothing, particularly, do not call AcceptDamageFrom at all
	void OnCollisionEnter(Collision col)
	{
		if (isColliding.Contains(col.gameObject)) return;
		isColliding.Add(col.gameObject);

		//print("A OnCollisionEnter executing... does nothing");
	}

	void OnCollisionExit(Collision col)
	{
		isColliding.Remove(col.gameObject);
	}

	public override int CauseDamageTo(DamageVisitable damagable)
	{
		//print("A CauseDamageTo executing...");
		int damageAmount = damage;
		return damageAmount;
	}

}
