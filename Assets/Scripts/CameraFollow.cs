using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    public Vector3 offset;
    

    void LateUpdate()
    {
        transform.position = Player.transform.position+offset;
        
    }

    
}
