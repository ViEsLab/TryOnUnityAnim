using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Animator anim;
    private CharacterController characterController;

    private int speedRotateId = Animator.StringToHash("SpeedRotate");
    private int speedZId = Animator.StringToHash("SpeedZ");
    private int vaultId = Animator.StringToHash("Vault");
    private int colliderId = Animator.StringToHash("Collider");
    private int isHoldLogId = Animator.StringToHash("IsHoldLog");
    private Vector3 matchTarget = Vector3.zero;

    public GameObject unityLog = null;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        anim.SetFloat(speedZId, Input.GetAxis("Vertical") * 4.1f);
        anim.SetFloat(speedRotateId, Input.GetAxis("Horizontal") * 126);

        bool isVault = false;
        if (anim.GetFloat(speedZId) > 3 && anim.GetCurrentAnimatorStateInfo(0).IsName("Locomotion")) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * 0.3f, transform.forward, out hit, 4f)) {
                if (hit.collider.tag == "Obstacle") {
                    if (hit.distance > 3) {
                        Vector3 point = hit.point;
                        point.y = hit.collider.transform.position.y + hit.collider.bounds.size.y + 0.07f;
                        matchTarget = point;
                        isVault = true;
                    }
                }
            }
        }

        anim.SetBool(vaultId, isVault);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Vault") && anim.IsInTransition(0) == false) {
            anim.MatchTarget(
                matchTarget,
                Quaternion.identity,
                AvatarTarget.LeftHand,
                new MatchTargetWeightMask(Vector3.one, 0),
                0.32f,
                0.4f);
        }

        characterController.enabled = anim.GetFloat(colliderId) < 0.05f;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Log") {
            Destroy(other.gameObject);
            CarryWood();
        }
    }

    void CarryWood() {
        unityLog.SetActive(true);
        anim.SetBool(isHoldLogId, true);
    }
}