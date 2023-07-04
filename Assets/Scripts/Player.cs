using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Animator anim;

    private int speedId = Animator.StringToHash("Speed");
    private int isSpeedUpId = Animator.StringToHash("IsSpeedUp");
    private int horizontalId = Animator.StringToHash("Horizontal");

    private int speedRotateId = Animator.StringToHash("SpeedRotate");
    private int speedZId = Animator.StringToHash("SpeedZ");

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        anim.SetFloat(speedZId, Input.GetAxis("Vertical") * 4.1f);
        anim.SetFloat(speedRotateId, Input.GetAxis("Horizontal") * 126);

        // anim.SetFloat(speedId, Input.GetAxis("Vertical") * 4.1f);
        // anim.SetFloat(horizontalId, Input.GetAxis("Horizontal"));
        // if (Input.GetKeyDown(KeyCode.LeftShift)) {
        //     anim.SetBool(isSpeedUpId, true);
        // }
        // if (Input.GetKeyUp(KeyCode.LeftShift)) {
        //     anim.SetBool(isSpeedUpId, false);
        // }
    }
}