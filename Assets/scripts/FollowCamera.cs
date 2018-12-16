using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject player;
    public float xoff;

    private void FixedUpdate()
    {
        Vector3 pos = player.transform.position;
        gameObject.transform.position = new Vector3(pos.x + xoff, 0f, -300);
    }
}
