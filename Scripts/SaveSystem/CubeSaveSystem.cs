using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class CubeSaveSystem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] Cube cubePrefab;

    public static List<Cube> spwanCube = new List<Cube>();

    const string CUBE_OBJECT_SUB = "/cubes";
    const string CUBE_OBJECT_COUNT_SUB = "/cubes.count";




    void Awake()
    {
        LoadCubeObject();

    }



    void OnApplicationQuit()
    {
        SaveCubeObject();
    }




    void SaveCubeObject()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + CUBE_OBJECT_SUB + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + CUBE_OBJECT_COUNT_SUB + SceneManager.GetActiveScene().buildIndex;

        FileStream countStream = new FileStream(countPath, FileMode.Create);

        formatter.Serialize(countStream, spwanCube.Count);
        countStream.Close();


        for (int i = 0; i < spwanCube.Count; i++)
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            CubeData data = new CubeData(spwanCube[i]);

            formatter.Serialize(stream, data);
            stream.Close();
        }

    }






    void LoadCubeObject()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + CUBE_OBJECT_SUB + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + CUBE_OBJECT_COUNT_SUB + SceneManager.GetActiveScene().buildIndex;
        int gameObjectCount = 0;

        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);

            gameObjectCount = (int)formatter.Deserialize(countStream);
            countStream.Close();
        }


        for (int i = 0; i < gameObjectCount; i++)
        {
            if (File.Exists(path + i))
            {
                FileStream stream = new FileStream(path + i, FileMode.Open);
                CubeData data = formatter.Deserialize(stream) as CubeData;

                stream.Close();

                Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);
                Cube cubeObj = Instantiate(cubePrefab, position, Quaternion.identity);


            }

        }
    }




}

