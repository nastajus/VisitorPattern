using UnityEngine;
using System.Collections;

//suppose "A" is the "Zombie" which is attacking
//and that "A" can only attack "B".
public class A : Thing {

	bool isColliding = false; // required to limit multiple executions for a single OnCollisionEnter to once per instance

	int damage = 3;


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

	public override int CauseDamageTo(DamageVisitable damagable)
	{
		print("A CauseDamageTo executing...");
		int damageAmount = damage;
		return damageAmount;
	}

}
