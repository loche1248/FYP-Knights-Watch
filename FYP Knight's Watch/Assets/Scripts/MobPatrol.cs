using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPatrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool mRight = true;

    public Transform groundDetect;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(groundDetect.position, Vector2.down, distance);
        if (ground.collider == false)
        {
            if(mRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                mRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                mRight = true;
            }
        }


    }
}
