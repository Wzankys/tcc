﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SelectionInfo
{
    public SelectedCharacter selectedCharacter;
}

[System.Serializable]
public struct SelectedCharacter
{
    public GameObject prefab;    
    public int number;
}

[System.Serializable]
public struct SelectedArena
{
    public Sprite sprite;
}