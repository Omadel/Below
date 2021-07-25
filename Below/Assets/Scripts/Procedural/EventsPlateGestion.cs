using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsPlateGestion : MonoBehaviour
{
    [SerializeField]
    public EventsVariants[] @event;
    [SerializeField]
    GameObject section=null;
    [SerializeField]
    public bool isManualySetted = false;
    [SerializeField]
    public bool isRandomSelection = true;


    void Start()
    {
        if (isRandomSelection)
        {
            RandomPick();
        }
    }
    public void UpdateEvent(int index)
    {
        SetVariant(index);
    }
    public void RandomPick()
    {
        int randomSeed = Random.Range(0, @event.Length);
        Debug.Log(randomSeed);
        UpdateEvent(randomSeed);
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
        isManualySetted = false;
        isRandomSelection = false;
    }
    void SetVariant(int index)
    {
        isManualySetted = false;
        if (section != null)
        {
            DestroyImmediate(section.gameObject);
        }
        GameObject b = Instantiate(@event[index].variant.gameObject);
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
        GameObject b = Instantiate(@event[index].variant.gameObject);
        b.transform.parent = transform;
        b.transform.position = transform.position;
        b.transform.rotation = transform.rotation;
        section = b;
    }

    private void OnDrawGizmos()
    {
        if(isRandomSelection)
        {
            Gizmos.DrawCube(transform.position,new Vector3(0.5f,100,0.5f));
        }
    }
}
[System.Serializable]
public struct EventsVariants
{
    public EventVariant variant;
}
