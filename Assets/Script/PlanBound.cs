using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanBound : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -bound.x;
        maxX = bound.x;
        minY = -bound.y;
        maxY = bound.y;
    }

    // Update is called once per frame
    void Update()
    {
        Bound();
    }
    void Bound()
    {
        Vector3 temp = transform.position;
        if (temp.x > maxX)
        {
            temp.x = maxX;
        }
        else if (temp.x < minX)
        {
            temp.x = minX;
        }

        if (temp.y > maxY)
        {
            temp.y = maxY;
        }
        else if (temp.y < minY)
        {
            temp.y = minY;
        }
        Drskill3.v2 = transform.position = temp;
        Boss2.v2 = temp;
    }
}
