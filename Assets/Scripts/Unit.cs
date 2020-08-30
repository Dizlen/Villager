using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Manager manager;

    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }

}
