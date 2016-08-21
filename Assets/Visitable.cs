using UnityEngine;
using System.Collections;

public interface Visitable {

	void Accept(Visitor visitor);

}
