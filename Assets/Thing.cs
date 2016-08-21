using UnityEngine;
using System.Collections;


//it seems inheriently wrong to invoke Accept from within Visit... but I cannot prove nor disprove this easily.
//however in this case since the "Thing" class is designed to be both the Visitor + Visitable, it may actually make sense
//thus I want to conditionally control execution of the Accept call here
//if A is arriving, invoke

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
	}

	void OnCollisionExit(Collision col)
	{
		isColliding = false;
	}

	public void Visit(Visitable visitiable)
	{
		print(visitiable + " visits " + this + ", but so what?" );
		ReduceHealthBWhenAinteracts();
	}

	public void Accept(Visitor visitor)
	{
		print(visitor + " accepts " + this);
		visitor.Visit(this);
	}

	//goal is to only trigger this method from A colliding with B, and not vice-versa
	//ideally in a manner that seems clean
	private void ReduceHealthBWhenAinteracts()
	{
		health -= 3;
		print("health of : " + this + " is: " + health);
	}

}
