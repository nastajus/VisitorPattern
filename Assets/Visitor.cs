using UnityEngine;
using System.Collections;

public interface DamageVisitor {

	void CauseDamageTo(DamageVisitable visitable);

}
