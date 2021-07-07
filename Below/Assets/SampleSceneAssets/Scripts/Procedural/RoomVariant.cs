using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVariant : MonoBehaviour
{
    RoomGenerator BaseRoom;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireMesh(BaseRoom.gameObject.GetComponent<MeshFilter>().mesh,transform.position);
    }
}
