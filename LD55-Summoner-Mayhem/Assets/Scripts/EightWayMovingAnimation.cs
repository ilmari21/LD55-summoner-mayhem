using UnityEngine;
using System.Collections;
using UnityEditor.AnimatedValues;

public class EightWayMovingAnimation : MonoBehaviour {
	bool wasMoving;
	int lastAnimSector;

	Animator animator;
	Transform sprite;
	Vector3 lastPosition;

	PlayerController playerController;
	PlayerState lastPlayerState;

	//int[] mapSectorToFlipped = new int[] {0, 1, 2, 3, 4, 3, 2, 1};
    public string[] idleAnimations =
        new string[] {"Paladin_Gun_Idle_North", "Paladin_Gun_Idle_NorthEast", "Paladin_Gun_Idle_East", "Paladin_Gun_Idle_SouthEast",
                        "Paladin_Gun_Idle_South", "Paladin_Gun_Idle_SouthWest", "Paladin_Gun_Idle_West", "Paladin_Gun_Idle_NorthWest"};
    public string[] movingAnimations =
        new string[] {"Paladin_Gun_Run_North", "Paladin_Gun_Run_NorthEast", "Paladin_Gun_Run_East", "Paladin_Gun_Run_SouthEast",
                        "Paladin_Gun_Run_South", "Paladin_Gun_Run_SouthWest", "Paladin_Gun_Run_West", "Paladin_Gun_Run_NorthWest"};
    public string[] shootingAnimations =
        new string[] { }; 
    public string[] meleeAnimations =
        new string[] { };

    //void SetSpriteFlip(bool flipped) {
    //	var scale = sprite.localScale;
    //	scale.x = (flipped ? -1 : 1) * Mathf.Abs(scale.x);
    //	sprite.localScale = scale;
    //}

    void Awake () {
		playerController = GetComponent<PlayerController>();
		animator = GetComponent<Animator>();
		sprite = transform.Find ("Sprite");
	}
	
	void FixedUpdate () {
        var state = playerController.playerState;
        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var d = target - transform.position;
		d.z = 0;
        float shortestAngle = Vector3.Angle (Vector3.up, d);
		float clockwiseAngle = d.x >= 0 ? shortestAngle : 360 - shortestAngle;
		int sector = ((int)(clockwiseAngle + 22.5f) % 360) / 45;
		//print(sector);

		if (state != lastPlayerState || sector != lastAnimSector)
		{
			if (state == PlayerState.Idle)
			{
				animator.Play(idleAnimations[sector]);
			}
			else if (state == PlayerState.Moving) 
			{
                animator.Play(movingAnimations[sector]);
            }
            else if (state == PlayerState.Shooting)
            {
                animator.Play(shootingAnimations[sector]);
            }
            else if (state == PlayerState.Melee)
            {
                animator.Play(meleeAnimations[sector]);
            }
        }

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

        //lastPosition = transform.position;
        //wasMoving = nowMoving;

        lastPlayerState = state;
        lastAnimSector = sector;
    }
}
