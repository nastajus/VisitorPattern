using UnityEngine;
using System.Collections;

//My application of DamageVisitor Pattern in Unity
//GameObject A falls onto GameObject B.  Only A is supposed to trigger the AcceptDamageFrom method of B.

public class Thing : MonoBehaviour, DamageVisitable, DamageVisitor {

	public int health = 10;

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

	}

	void OnCollisionExit(Collision col)
	{
		isColliding = false;
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
