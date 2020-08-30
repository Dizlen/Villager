using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameCanvas : MonoBehaviour
{
    private static MainGameCanvas _instance;
    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
