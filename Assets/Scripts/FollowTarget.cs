using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    private Transform player;
    private Vector3 offset;
    private float smoothing = 3;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    void LateUpdate() {
        Vector3 targetPos = player.position + player.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothing);
        transform.LookAt(player);
    }
}