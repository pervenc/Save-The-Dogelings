using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackGround : MonoBehaviour {
     void Start()
    {
        
    }

    private static AudioBackGround instance = null;
    public static AudioBackGround Instance
    {
        get { return instance; }
    }
    void Awake()
    {

        if (instance !=null && instance!=this)

        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
