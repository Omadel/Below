using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomGenerator : MonoBehaviour
{
    [SerializeField]
    public RoomVariants[] variants;
    [SerializeField]
    GameObject section=null;
    [SerializeField]
    bool isRandomSelection=true;


     void Start()
    { 
        if (isRandomSelection)
        {
            Debug.Log("fkxcvffrej");
             RandomPick();
        }
    }
    
    public void UpdateRoom(int index)
    {
        SetVariant(index);
    }


    void RandomPick()
    {
        int randomSeed = Random.Range(0, variants.Length);
        Debug.Log(randomSeed);
        UpdateRoom(randomSeed);
    }

    public void ClearRoom()
    {
        if(section!=null)
        {
            DestroyImmediate(section);
            section = null;
            
        }
        isRandomSelection = true;
    }
    void SetVariant(int index)
    {
        isRandomSelection = false;
        if(section!=null)
        {
            DestroyImmediate(section.gameObject);
        }
        GameObject b=Instantiate(variants[index].variant.gameObject);
        b.transform.parent =transform;
        b.transform.position =transform.position;
        b.transform.rotation=transform.rotation;
        section = b;
    }
}

[System.Serializable]
public struct RoomVariants
{
    public RoomVariant variant;
}
