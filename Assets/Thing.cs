using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//My application of DamageVisitor Pattern in Unity
//GameObject A falls onto GameObject B.  Only A is supposed to trigger the AcceptDamageFrom method of B.

public abstract class Thing : MonoBehaviour, DamageVisitable, DamageVisitor {

	public int health = 10;

	// required to limit multiple executions for a single OnCollisionEnter to once per instance
	List<GameObject> isColliding = new List<GameObject>();

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (isColliding.Contains(col.gameObject)) return;
		isColliding.Add(col.gameObject);

		print(" Thing parent OnCollisionEnter executing, you should override this....  col.gameObject.name: " + col.gameObject.name + ", this.gameObject.name: " + this.gameObject.name);
		Debug.LogError("Seriously, make your child override this, I'm not joking");

	}

	void OnCollisionExit(Collision col)
	{
		isColliding.Remove(col.gameObject);
	}



	public virtual int AcceptDamageFrom(DamageVisitor damager)
	{
		print("Thing AcceptDamageFrom executes... " + damager + " accepts damage from " + this);
		int healthAmount = damager.CauseDamageTo(this);
		return healthAmount;
	}
	
	public virtual int CauseDamageTo(DamageVisitable damagable)
	{
		print("Thing CauseDamageTo executing... ");// + damagable + " causes damage to " + this);
		return 0;
	}

}
