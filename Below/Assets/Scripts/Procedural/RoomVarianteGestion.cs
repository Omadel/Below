using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomVarianteGestion : MonoBehaviour
{
    [SerializeField]
    public RoomVariant[] variants;
    [SerializeField]
    GameObject section=null;
    [SerializeField]
    bool isRandomSelection=true;


     void Start()
     { 
        if (isRandomSelection)
        {
             RandomPick();
        }
     }
    
    public void UpdateRoom(int index)
    {
        SetVariant(index);
    }


    public void RandomPick()
    {
        int randomSeed = Random.Range(0, variants.Length);
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
        GameObject b=Instantiate(variants[index].gameObject);
        b.transform.parent =transform;
        b.transform.position =transform.position;
        b.transform.rotation=transform.rotation;
        section = b;
    }
}
