using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class s_testJson : MonoBehaviour {

    [System.Serializable]
    public class testClass
    {
        [SerializeField]
        public int id;
        [SerializeField]
        public string name;
        [SerializeField]
        public Vector3 unVector;

        public testClass(int _id , string _name , Vector3 _vec3)
        {
            id = _id;
            name = _name;
            unVector = _vec3;
        }
    }

    public testClass asd = new testClass(0,"asd",new Vector3(1,2,3));
    public testClass asd1 = new testClass(1, "asdasd", new Vector3(221, 32, 43));

    public testClass asd2 = new testClass(2, "2", new Vector3(2, 2, 2));
    public testClass asd3 = new testClass(2, "2", new Vector3(2, 2, 2));


    void Start ()
    {
        string json = JsonUtility.ToJson(asd);
        string json2 = JsonUtility.ToJson(asd1);


        if (!Directory.Exists("TestJson"))
            Directory.CreateDirectory("TestJson");
        string path = "TestJson/test.json";

        

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path,false);
        writer.WriteLine(json);
        writer.WriteLine(json2);

        writer.Close();


        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        asd2 = JsonUtility.FromJson<testClass>(reader.ReadLine());
        asd3 = JsonUtility.FromJson<testClass>(reader.ReadLine());
        reader.Close();
    }

    void Update ()
    {
		
	}
}
