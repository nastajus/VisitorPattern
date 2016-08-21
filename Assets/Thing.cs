using UnityEngine;
using System.Collections;

//My application of Visitor Pattern in Unity
//GameObject A falls onto GameObject B.  Only A is supposed to trigger the Accept method of B.

public class Thing : MonoBehaviour, Visitable, Visitor {

	int health = 10;

	bool isColliding = false; // required to limit multiple executions for a single OnCollisionEnter to once per instance

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (isColliding) return;
		isColliding = true;

		print("col.gameObject.name: " + col.gameObject.name + ", this.gameObject.name: " + this.gameObject.name);
		
		//conditional acceptance, only when A visits B, not vice-versa
		A a = col.gameObject.GetComponent<A>();
		if (a)
		{
			Visitor visitor = col.gameObject.GetComponent<Visitor>();
			Visitable visitable = gameObject.GetComponent<Visitable>();
			visitable.Accept(visitor);
		}

		//alternatively, this can just always call visitable.Accept(visitor), but this defeats the control sought.
	}

	void OnCollisionExit(Collision col)
	{
		isColliding = false;
	}

	//goal is to only trigger this method from A colliding with B, and not vice-versa
	//ideally in a manner that seems clean
	private void ReduceHealthBWhenAinteracts()
	{
		health -= 3;
		print("health of : " + this + " is: " + health);
	}

	public void Accept(Visitor visitor)
	{
		print(visitor + " accepts " + this);
		visitor.Visit(this);
	}
	
	public void Visit(Visitable visitiable)
	{
		print(visitiable + " visits " + this);
		ReduceHealthBWhenAinteracts();
	}

}
