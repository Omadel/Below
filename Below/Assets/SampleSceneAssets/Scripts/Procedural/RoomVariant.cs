using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVariant : MonoBehaviour
{
    [SerializeField]
    RoomGenerator BaseRoom;
    private void OnDrawGizmos()
    {
        if (BaseRoom != null)
        {
            Gizmos.DrawWireMesh(BaseRoom.gameObject.GetComponent<MeshFilter>().mesh, transform.position);
        }
    }
}
