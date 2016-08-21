using UnityEngine;
using System.Collections;

//My application of DamageVisitor Pattern in Unity
//GameObject A falls onto GameObject B.  Only A is supposed to trigger the AcceptDamageFrom method of B.

public class Thing : MonoBehaviour, DamageVisitable, DamageVisitor {

	int health = 10;

	bool isColliding = false; // required to limit multiple executions for a single OnCollisionEnter to once per instance

	void Start () {
	
	}
	
	void Update () {
	
	}

	protected virtual void OnCollisionEnter(Collision col)
	{
		if (isColliding) return;
		isColliding = true;

		print(" Thing parent OnCollisionEnter executing, you should override this....  col.gameObject.name: " + col.gameObject.name + ", this.gameObject.name: " + this.gameObject.name);
		Debug.LogError("Seriously, make your child override this, I'm not joking");
		

		//this logic isn't normally intended to be executed, it's just present in case as a default.
		//when "A" extended "Thing", it overrode this method, disregarding it, and always executing it's own equivalent copy of below
		//when "B" extended "Thing", it overrode this also, disregards it, and never executes anything.
		DamageVisitor damager = col.gameObject.GetComponent<DamageVisitor>();
		DamageVisitable damagable = gameObject.GetComponent<DamageVisitable>();
		damagable.AcceptDamageFrom(damager);
		//this can just always call visitable.AcceptDamageFrom(visitor)
		//however, the child class "B" can override the AcceptDamageFrom method
	}

	void OnCollisionExit(Collision col)
	{
		isColliding = false;
	}

	//goal is to only trigger this method from A colliding with B, and not vice-versa
	//ideally in a manner that seems clean
	private int ReduceHealthBWhenAinteracts()
	{
		health -= 3;
		print("health of : " + this + " is: " + health);
		return health;
	}

	public int AcceptDamageFrom(DamageVisitor damager)
	{
		print(damager + " accepts damage from " + this);
		int healthAmount = damager.CauseDamageTo(this);
		return healthAmount;
	}
	
	public virtual int CauseDamageTo(DamageVisitable damagable)
	{
		print("Thing CauseDamageTo executing... " + damagable + " causes damage to " + this);
		int damageAmount = ReduceHealthBWhenAinteracts();
		return damageAmount;
	}

}
