using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Character Info")]
public class CharacterInfo : ScriptableObject
{
    public GameObject prefab;
    [FormerlySerializedAs("animationController")] public AnimatorOverrideController loadingAnimationController;
}
