using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RoomGenerator : MonoBehaviour
{
    [SerializeField]
    RoomVariants[] variants;
    GameObject section;
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
    void SetVariant(int index)
    {
        if(section!=null)
        {
            DestroyImmediate(section.gameObject);
        }
        GameObject b=Instantiate(variants[index].variant);
        b.transform.parent =transform;
        b.transform.position =Vector3.zero;
        section = b;

    }

}


[System.Serializable]
struct RoomVariants
{
    public GameObject variant;
    public bool isActive;
}
