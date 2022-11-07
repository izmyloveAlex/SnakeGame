using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Borders : MonoBehaviour
{
    public float max_x;
    public float min_x;
    void Update()
    {
        if (this.transform.position.x > max_x)
            this.transform.position = new UnityEngine.Vector3(max_x, this.transform.position.y, this.transform.position.z);

        if (this.transform.position.x < min_x)
            this.transform.position = new UnityEngine.Vector3(min_x, this.transform.position.y, this.transform.position.z);
    }
}
