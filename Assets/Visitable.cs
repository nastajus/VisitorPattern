using UnityEngine;
using System.Collections;

public interface DamageVisitable {

	int AcceptDamageFrom(DamageVisitor visitor);

}
