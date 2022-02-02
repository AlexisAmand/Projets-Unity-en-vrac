using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}
