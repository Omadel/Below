using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomVarianteGestion : MonoBehaviour
{
    [SerializeField]
    public RoomVariant[] variants;
    [SerializeField]
    int section;
    [SerializeField]
    bool isRandomSelection;


     void Start()
     {
        
        print(isRandomSelection);
        if (isRandomSelection)
        {
             RandomPick();
        }
     }
    
    public void UpdateRoom(int index)
    {
        isRandomSelection = false;
        SetVariant(index);
    }


    public void RandomPick()
    {
        int randomSeed = Random.Range(0, variants.Length);
        UpdateRoom(randomSeed);
    }

    public void ClearRoom()
    {

        isRandomSelection = true;
        variants[section].gameObject.SetActive(false);

    }
    void SetVariant(int index)
    {
        
        variants[section].gameObject.SetActive(false);
        section = index;

        variants[section].gameObject.SetActive(true);

        #region Instansiate 
        //if(section!=null)
        //{

        //DestroyImmediate(section.gameObject);
        //}
        //GameObject b=Instantiate(variants[index].gameObject);
        //b.transform.parent =transform;
        //b.transform.position =transform.position;
        //b.transform.rotation=transform.rotation;
        //section = b;
        #endregion
    }
}
