using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    public GameObject[] platformGroups;
    public GameObject player;
    Vector2 limitPos, lastPos, firstPos;
    Vector2 pos;

    private const float obsjectSize = 22.3f;
    private int count;

    private void Start()
    {
        int size = platformGroups.Length;
        for (int i = 0; i < size; i++)
        {
            pos = new Vector2(i * obsjectSize, 0);
            platformGroups[i].transform.position = pos;
        }

        count = 0;
        limitPos = platformGroups[size - 2].transform.position;
        lastPos = platformGroups[0].transform.position;
        firstPos = platformGroups[size - 1].transform.position;
    }

    private void Update()
    {
        if (player.transform.position.x > limitPos.x)
        {
            limitPos = new Vector2(limitPos.x + obsjectSize, 0);
            firstPos = new Vector2(firstPos.x + obsjectSize, 0);
            lastPos = new Vector2(lastPos.x + obsjectSize, 0);

            platformGroups[count].transform.position = firstPos;

            count++;
        }

        if (count >= platformGroups.Length)
            count = 0;
    }
}
