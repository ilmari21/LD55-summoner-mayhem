using UnityEngine;
using System.Collections;
//using UnityEditor.AnimatedValues;

public class EightWayMovingAnimation : MonoBehaviour {
	int lastAnimSector;

	public Animator animator;
	Transform sprite;

	public PlayerController playerController;
	PlayerState lastPlayerState;

    public int publicSector;

    public string[] idleAnimations =
        new string[] {"Paladin_Idle_North", "Paladin_Idle_NorthEast", "Paladin_Idle_East", "Paladin_Idle_SouthEast",
                        "Paladin_Idle_South", "Paladin_Idle_SouthWest", "Paladin_Idle_West", "Paladin_Idle_NorthWest"};
    public string[] movingAnimations =
        new string[] {"Paladin_Run_North", "Paladin_Run_NorthEast", "Paladin_Run_East", "Paladin_Run_SouthEast",
                        "Paladin_Run_South", "Paladin_Run_SouthWest", "Paladin_Run_West", "Paladin_Run_NorthWest"};
    public string[] meleeAnimations =
        new string[] {"Paladin_Sword_North", "Paladin_Sword_NorthEast", "Paladin_Sword_East", "Paladin_Sword_SouthEast",
                        "Paladin_Sword_South", "Paladin_Sword_SouthWest", "Paladin_Sword_West", "Paladin_Sword_NorthWest"};

    void Awake () {
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
        publicSector = sector;

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
            //else if (state == PlayerState.Melee)
            //{
            //    animator.Play(meleeAnimations[sector]);
            //}
        }

        lastPlayerState = state;
        lastAnimSector = sector;
    }
}
