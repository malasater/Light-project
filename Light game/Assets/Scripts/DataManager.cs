using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    // singleton
    protected DataManager() { }
    //public static new DataManager Instance;


    // singleton
    private static DataManager dataManager;
    public static DataManager instance
    {
        get
        {
            // if we don't have it
            if (!dataManager)
            {
                // then find it 
                dataManager = FindObjectOfType(typeof(DataManager)) as DataManager;
                // if null
                if (!dataManager)
                {
                    Debug.LogError("There needs to be one active DataManager script on a GameObject in your scene.");
                }
                else
                {
                    // initialize 
                    //dataManager.Init ();
                }
            }
            return dataManager;
        }
    }
}



