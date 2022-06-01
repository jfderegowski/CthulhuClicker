using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNpcs : MonoBehaviour
{
    public List<GameObject> destination = new List<GameObject>();
    public GameObject NPC;
    
    [SerializeField] private BuildingsShopPanel _buildingsShopPanel;

    private int _numberOfNpcs;
    private int _numberOfSpawnedNpcs;

    private void Start()
    {
        SpawnNpc();
    }

    public void SpawnNpc()
    {
        _numberOfNpcs = (int)_buildingsShopPanel.Follower.Count;
        
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
