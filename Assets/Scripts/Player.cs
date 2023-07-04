using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Animator anim;

    private int speedRotateId = Animator.StringToHash("SpeedRotate");
    private int speedZId = Animator.StringToHash("SpeedZ");

    private int vaultId = Animator.StringToHash("Vault");

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        anim.SetFloat(speedZId, Input.GetAxis("Vertical") * 4.1f);
        anim.SetFloat(speedRotateId, Input.GetAxis("Horizontal") * 126);

        bool isVault = false;
        if (anim.GetFloat(speedZId) > 3) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * 0.3f, transform.forward, out hit, 2)) {
                if (hit.collider.tag == "Obstacle") {
                    isVault = true;
                }
            }
        }

        anim.SetBool(vaultId, isVault);
    }
}