//Reference - https://www.youtube.com/watch?v=hk6cUanSfXQ
//Reference - https://www.youtube.com/watch?v=XNQQLr0E9TY
//Reference - https://www.youtube.com/watch?v=G9Wa0XZ2a2o
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    public int type;

    public void RoomDestroy()
    {
        Destroy(gameObject);
    }
}
