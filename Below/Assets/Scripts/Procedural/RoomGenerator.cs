using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RoomGenerator : MonoBehaviour
{
    [SerializeField]
    public RoomVariants[] variants;
    GameObject section;
    [HideInInspector]
    public string roomSelection = "Random room";

    public void Start()
    {
       if(RandomCheck());
        {
            RandomPick();
        }
    }
    public void UpdateRoom()
    {
        for (int i = 0; i < variants.Length; i++)
        {
            if(variants[i].isActive)
            {
                SetVariant(i);
                i = variants.Length + 1;
            }
        }
    }
    bool RandomCheck()
    {

        for (int i = 0; i < variants.Length; i++)
        {
            if (variants[i].isActive)
            {
                return false;
            }
        }
        return true;

    }

    void RandomPick()
    {
        int randomSeed = Random.Range(0, variants.Length);
        SetVariant(randomSeed);
        variants[randomSeed].isActive = true;

    }

    public void ClearRoom()
    {
        for (int i = 0; i < variants.Length; i++)
        {
            variants[i].isActive = false;
        }
        if(section!=null)
        {
            DestroyImmediate(section);
        }
    }
    void SetVariant(int index)
    {
        if(section!=null)
        {
            DestroyImmediate(section.gameObject);
        }
        GameObject b=Instantiate(variants[index].variant.gameObject);
        b.transform.parent =transform;
        b.transform.position =Vector3.zero;
        section = b;
    }
    public void ResetBool(int index)
    {
        for (int i = 0; i < variants.Length; i++)
        {
            if (i != index)
            {
                variants[i].isActive = false;
            }
            else
            {
                variants[i].isActive = true;
            }
        }
    }

}

[System.Serializable]
public struct RoomVariants
{
    public RoomVariant variant;
    [HideInInspector]
    public bool isActive;
}
