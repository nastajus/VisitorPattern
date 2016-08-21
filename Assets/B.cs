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

	public override int AcceptDamageFrom(DamageVisitor damager)
	{
		print("B AcceptDamageFrom executes... " + damager + " accepts damage from " + this);
		health -= damager.CauseDamageTo(this);

		//it's debatable whether this should return 1) new health, or 2) damage amount caused, or 3) some struct or class containing both and/or more of these
		//for the moment the simplest option is to just return the quantity just manipulated, health
		return health;
	}

}
