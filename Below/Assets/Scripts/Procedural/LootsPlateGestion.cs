using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootsPlateGestion : MonoBehaviour
{
    [SerializeField]
    public LootsVariants[] loots;
    [SerializeField]
    GameObject section=null;
    [SerializeField]
    bool isManualySetted = false;
    [SerializeField]
    bool isRandomSelection = true;


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
        int randomSeed = Random.Range(0, loots.Length);
        Debug.Log(randomSeed);
        UpdateRoom(randomSeed);
    }
    public void RandomSet()
    {
        isRandomSelection = true;
    }
    public void ClearRoom()
    {
        if (section != null)
        {
            DestroyImmediate(section);
            section = null;

        }
    }
    void SetVariant(int index)
    {
        isManualySetted = false;
        if (section != null)
        {
            DestroyImmediate(section.gameObject);
        }
        GameObject b = Instantiate(loots[index].variant.gameObject);
        b.transform.parent = transform;
        b.transform.position = transform.position;
        b.transform.rotation = transform.rotation;
        section = b;
    }
    public void SetVariantManualy(int index)
    {
        isManualySetted = true;
        if (section != null)
        {
            DestroyImmediate(section.gameObject);
        }
        GameObject b = Instantiate(loots[index].variant.gameObject);
        b.transform.parent = transform;
        b.transform.position = transform.position;
        b.transform.rotation = transform.rotation;
        section = b;
    }

    private void OnDrawGizmos()
    {
        if(isRandomSelection)
        {
            Gizmos.DrawCube(transform.position,new Vector3(1,100,1));
        }
    }
}
[System.Serializable]
public struct LootsVariants
{
    public LootVariant variant;
}
