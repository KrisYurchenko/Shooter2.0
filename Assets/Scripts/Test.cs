using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private int number = 5;
    private double doubleNumber = 314.5235235f;
    private float floatNumber = 314.5235235f;
    private string stroka = "Hello";
    private bool flag = true;
    private bool flag2 = false;



    // вызывается только на первом кадре
    void Start()
    {
        // print(number);
        // print(stroka);
        // print(flag);
        // print(flag2);
        // print(floatNumber);
        // print(doubleNumber);

        if (flag)
        {
            print("Flag is true");
        }
        else
        {
            print("Flag is not true");
        }

        if (number > 10)
        {
            print("number > 10");
        }
        else if (number == 10)
        {
            print("number == 10");
        }
        else
        {
            print("number < 10");
        }
        
        print(this.gameObject.name);

        gameObject.name = "NewName";
        
        print(this.gameObject.name);

        var result = CalculateSum(out var result2);
        Debug.Log(result);

        var t = GetComponent<Rigidbody>();
    }

    private int CalculateSum(out int varible2)
    {
        varible2 = 124124;
        return 5 + 5;
    }
}
