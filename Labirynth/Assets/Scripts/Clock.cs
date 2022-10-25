using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public bool addTime; //true dodaje czas, a false odejmuje czas
    public int time = 5;


    public override void Picked()
    {
        int sign;
        if (addTime)
        {
            sign = 1;
        }
        else
        {
            sign = -1;
        }
        
        GameManager.gameManager.AddTime(time * sign);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
