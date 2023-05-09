using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    void Awake()
    {
        CubeSaveSystem.spwanCube.Add(this);


    }


    void OnDestroy()
    {
        CubeSaveSystem.spwanCube.Remove(this);

    }
}
