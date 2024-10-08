using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;


    void Start()
    {
        car = GameObject.Find("car");
        flag = GameObject.Find("flag");
        distance = GameObject.Find("distance");
    }

    void Update()
    {
        float length = 
            flag.transform.position.x - car.transform.position.x;
        distance.GetComponent<TextMeshProUGUI>().text =
            "Distance:" + length.ToString("F2") + "m";
    }
}
