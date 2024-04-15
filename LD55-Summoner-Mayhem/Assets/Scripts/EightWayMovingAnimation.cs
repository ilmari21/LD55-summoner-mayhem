using UnityEngine;
using System.Collections;

public class EightWayMovingAnimation : MonoBehaviour {
	bool wasMoving;
	int lastAnimSector;

	Animator animator;
	Transform sprite;
	Vector3 lastPosition;

	//int[] mapSectorToFlipped = new int[] {0, 1, 2, 3, 4, 3, 2, 1};
	public string[] walkingAnimations =
		new string[] {"Paladin_Gun_Run_North", "Paladin_Gun_Run_NorthEast", "Paladin_Gun_Run_East", "Paladin_Gun_Run_SouthEast", 
						"Paladin_Gun_Run_South", "Paladin_Gun_Run_SouthWest", "Paladin_Gun_Run_West", "Paladin_Gun_Run_NorthWest"};
    public string[] idleAnimations =
        new string[] {"Paladin_Gun_Idle_North", "Paladin_Gun_Idle_NorthEast", "Paladin_Gun_Idle_East", "Paladin_Gun_Idle_SouthEast",
                        "Paladin_Gun_Idle_South", "Paladin_Gun_Idle_SouthWest", "Paladin_Gun_Idle_West", "Paladin_Gun_Idle_NorthWest"};
    public string[] attackAnimations =
        new string[] {};

	//void SetSpriteFlip(bool flipped) {
	//	var scale = sprite.localScale;
	//	scale.x = (flipped ? -1 : 1) * Mathf.Abs(scale.x);
	//	sprite.localScale = scale;
	//}
	
	void Awake () {
		animator = GetComponent<Animator>();
		sprite = transform.Find ("Sprite");
	}
	
	void FixedUpdate () {
		var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var d = target - transform.position;
		d.z = 0;
        float shortestAngle = Vector3.Angle (Vector3.up, d);
		float clockwiseAngle = d.x >= 0 ? shortestAngle : 360 - shortestAngle;
		int sector = ((int)(clockwiseAngle + 22.5f) % 360) / 45;
		print(sector);

		//bool nowMoving = Vector3.Distance (transform.position, lastPosition) > Mathf.Epsilon;

		//int animSector = mapSectorToFlipped [sector];
		//SetSpriteFlip (sector != animSector);

		//if (lastAnimSector != animSector) { //vaihda inputtiin
		//	animator.Play (animationNames [animSector * 2 + (nowMoving ? 1 : 0)]);
		//} else if (wasMoving && !nowMoving) {
		//	animator.Play (animationNames[animSector * 2]);
		//} else if (!wasMoving && nowMoving) {
		//	animator.Play (animationNames[animSector * 2 + 1]);
		//}

		//lastAnimSector = animSector;
		//lastPosition = transform.position;
		//wasMoving = nowMoving;
	}
}
