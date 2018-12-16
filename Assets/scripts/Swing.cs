using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour {

    public Vector2 shootDirection;
    public TargetJoint2D sourceJoint;
    public LineRenderer rayDrawing;
    public AudioSource soundEffect;

    GameManager gameManager;

    private void Start()
    {
        sourceJoint = GetComponent<TargetJoint2D>();
        gameManager = FindObjectOfType<GameManager>();

        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (!Application.isMobilePlatform)
        {
            if (Input.GetMouseButtonDown(0)) Hold();
            if (Input.GetMouseButtonUp(0)) Release();
        }
        else
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) Hold();
            if (touch.phase == TouchPhase.Ended) Release();
        }

        //tJ2D.anchor = transform.position;

        rayDrawing.SetPosition(0, transform.position);
        rayDrawing.SetPosition(1, sourceJoint.target);

        //if (Input.GetKeyDown(KeyCode.Space)) Debug.Log("Anchor: " + tJ2D.anchor + " Target: " + tJ2D.target);
    }

    public void Hold()
    {
        soundEffect.Play();
        sourceJoint.enabled = true;
        rayDrawing.enabled = true;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 origin = new Vector2(transform.position.x, transform.position.y + 0.5f);

        Vector2 pos = mousePos - origin;

        RaycastHit2D hit = Physics2D.Raycast(origin, shootDirection);

        if (hit.collider != null)
        {
            sourceJoint.target = hit.point;
        }
    }

    public void Release()
    {
        sourceJoint.enabled = false;
        rayDrawing.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }

}
