using UnityEngine;
using System.Collections;

//suppose "A" is the "Zombie" which is attacking
//and that "A" can only attack "B".
public class A : Thing {

	bool isColliding = false; // required to limit multiple executions for a single OnCollisionEnter to once per instance

	protected override void OnCollisionEnter(Collision col)
	{
		if (isColliding) return;
		isColliding = true;

		print("A OnCollisionEnter executing... col.gameObject.name: " + col.gameObject.name + ", this.gameObject.name: " + this.gameObject.name);


		DamageVisitor damager = col.gameObject.GetComponent<DamageVisitor>();
		DamageVisitable damagable = gameObject.GetComponent<DamageVisitable>();
		damagable.AcceptDamageFrom(damager);
		//since this is in "A" class only, it would only invoke from here
		//this can just always call visitable.AcceptDamageFrom(visitor)
		//however, the child class "B" can override the AcceptDamageFrom method
	}


	void OnCollisionExit(Collision col)
	{
		isColliding = false;
	}

}
