using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    private static int ammoCount = 0;
   


    public Count(int aC)
    {
        ammoCount = aC;
    }

    public static void setCount(int aC)
    {
        ammoCount = aC;
    }

    public static int getCount()
    {
        return ammoCount;
    }

    public static int incrementCount()
    {
        ammoCount += 2;
        return ammoCount;
    }

    public static int decrementCount()
    {
        ammoCount -= 1;
        return ammoCount;
    }
}
