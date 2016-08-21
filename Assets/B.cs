using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//suppose "B" is the "Vehicle" which receives the attack, and only receives from "A" (Zombie)
public class B : Thing {

	// required to limit multiple executions for a single OnCollisionEnter to once per instance
	private List<GameObject> isColliding = new List<GameObject>();

	// initiates receipt of damage
	void OnCollisionEnter(Collision col)
	{
		if (isColliding.Contains(col.gameObject)) return;
		isColliding.Add(col.gameObject);

		print("B OnCollisionEnter executing... col.gameObject.name: " + col.gameObject.name + ", this.gameObject.name: " + this.gameObject.name);

		DamageVisitor damager = col.gameObject.GetComponent<DamageVisitor>();
		DamageVisitable damagable = gameObject.GetComponent<DamageVisitable>();
		damagable.AcceptDamageFrom(damager);
		//since this is in "A" class only, it would only invoke from here
		//this can just always call visitable.AcceptDamageFrom(visitor)
		//however, the child class "B" can override the AcceptDamageFrom method
	}

	void OnCollisionExit(Collision col)
	{
		isColliding.Remove(col.gameObject);
	}

	public override int AcceptDamageFrom(DamageVisitor damager)
	{
		int damageAmount = damager.CauseDamageTo(this);
		//print("B AcceptDamageFrom executes... " + this + " accepts damage amount " + damageAmount + " from " + damager );
		health -= damageAmount;

		ReportHealth();

		//it's debatable whether this should return 1) new health, or 2) damage amount caused, or 3) some struct or class containing both and/or more of these
		//for the moment the simplest option is to just return the quantity just manipulated, health
		return health;
	}

	private void ReportHealth()
	{
		print("health of : " + this + " is: " + health);
	}

}
