using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    void Awake()
    {
        SphereSaveSystem.spwanSphere.Add(this);


    }


    void OnDestroy()
    {
        SphereSaveSystem.spwanSphere.Remove(this);

    }
}
