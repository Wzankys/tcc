﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T> {

    private static T s_instance;
    public static T Instance {
        get {
            return s_instance != null ? s_instance : (s_instance = FindObjectOfType<T>());
        }
    }

    public static void setInstance(T newInstance)
    {
        s_instance = newInstance;
    }

}