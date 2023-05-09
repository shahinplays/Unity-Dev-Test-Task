using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SphereSaveSystem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] Sphere spherePrefab;

    public static List<Sphere> spwanSphere = new List<Sphere>();

    const string SPHERE_OBJECT_SUB = "/sphere";
    const string SPHERE_OBJECT_COUNT_SUB = "/sphere.count";




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
        string path = Application.persistentDataPath + SPHERE_OBJECT_SUB + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + SPHERE_OBJECT_COUNT_SUB + SceneManager.GetActiveScene().buildIndex;

        FileStream countStream = new FileStream(countPath, FileMode.Create);

        formatter.Serialize(countStream, spwanSphere.Count);
        countStream.Close();


        for (int i = 0; i < spwanSphere.Count; i++)
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            SphereData data = new SphereData(spwanSphere[i]);

            formatter.Serialize(stream, data);
            stream.Close();
        }

    }






    void LoadCubeObject()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + SPHERE_OBJECT_SUB + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + SPHERE_OBJECT_COUNT_SUB + SceneManager.GetActiveScene().buildIndex;
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
                SphereData data = formatter.Deserialize(stream) as SphereData;

                stream.Close();

                Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);
                Sphere cubeObj = Instantiate(spherePrefab, position, Quaternion.identity);


            }

        }
    }




}

