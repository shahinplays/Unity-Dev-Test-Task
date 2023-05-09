using UnityEngine;

[System.Serializable]
public class CubeData
{
    //Replace these example variable with your objects variables
    //that you wish to save
    public float[] position;

    public CubeData(Cube cube)
    {
        Vector3 objPos = cube.transform.position;

        position = new float[]
        {
            objPos.x, objPos.y, objPos.z
        };
    }


}
