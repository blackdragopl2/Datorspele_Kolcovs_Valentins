using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotation_speed = 0.1f;
    private float verMove = 0.0f;
    private float horMove = 0.0f;
    private int currentLevel = 0;

    //Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        horMove = Input.GetAxis("Horizontal");
        verMove = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(verMove, 0.0f, -horMove)*rotation_speed);

    }
}
