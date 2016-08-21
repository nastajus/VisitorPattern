using UnityEngine;
using System.Collections;

public class Thing : MonoBehaviour, Visitable, Visitor {

	bool isColliding = false;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (isColliding) return;
		isColliding = true;

		print("col.gameObject.name: " + col.gameObject.name + ", this.gameObject.name: " + this.gameObject.name);

		Visitor visitor = col.gameObject.GetComponent<Visitor>();
		visitor.Visit(this);
	}

	void OnCollisionExit(Collision col)
	{
		isColliding = false;
	}

	public void Visit(Visitable visitiable)
	{
		Accept((Visitor)visitiable);
		print("visitiable called by: " + visitiable);
	}

	public void Accept(Visitor visitor)
	{
		print("accept called by: " + visitor);
	}
}
