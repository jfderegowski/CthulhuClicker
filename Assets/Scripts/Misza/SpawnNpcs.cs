using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNpcs : MonoBehaviour
{
    [SerializeField] private int _numberOfNpcs;
    [SerializeField] private int _numberOfSpawnedNpcs;
    public List<GameObject> destination = new List<GameObject>();
    public GameObject NPC;

    private void Start()
    {
        SpawnNpc();
    }

    void SpawnNpc()
    {
        if ((_numberOfSpawnedNpcs < _numberOfNpcs) && (_numberOfSpawnedNpcs < destination.Count))
        {
            int max = 0;
            if (_numberOfNpcs < destination.Count)
            {
                max = _numberOfNpcs;
            }
            else
            {
                max = destination.Count;
            }
            int _numberOfSpawnedNpcs2 = _numberOfSpawnedNpcs;
            for (int i = _numberOfSpawnedNpcs2+1; i<=max; i++)
            {
                Instantiate(NPC, destination[_numberOfSpawnedNpcs].transform.position, Quaternion.identity);
                _numberOfSpawnedNpcs++;
            }
        }
    }
}
