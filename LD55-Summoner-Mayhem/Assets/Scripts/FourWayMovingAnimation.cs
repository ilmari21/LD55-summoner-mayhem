using UnityEngine;
using System.Collections;

public class FourWayMovingAnimation : MonoBehaviour {
	int lastAnimSector = -1;

	public Animator animator;

    string[] movingAnimations =
        new string[] {"Minion1_North", "Minion1_East", "Minion1_South", "Minion1_West" };

    void Awake () {
		animator = GetComponentInChildren<Animator>();
	}
	
	void Update () {
		var d = transform.forward;
		float shortestAngle = Vector3.Angle(Vector3.up, d);
		float clockwiseAngle = d.x >= 0 ? shortestAngle : 360 - shortestAngle;
		int sector = ((int)(clockwiseAngle + 45f) % 360) / 90;

		if (sector != lastAnimSector)
		{
			print(sector);
			animator.Play(movingAnimations[sector]);
		}

		lastAnimSector = sector;
	}
}
