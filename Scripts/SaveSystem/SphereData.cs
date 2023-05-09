using UnityEngine;

[System.Serializable]
public class SphereData
{
    //Replace these example variable with your objects variables
    //that you wish to save
    public float[] position;

    public SphereData(Sphere sphere)
    {
        Vector3 objPos = sphere.transform.position;

        position = new float[]
        {
            objPos.x, objPos.y, objPos.z
        };
    }


}
