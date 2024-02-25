using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCapsule : MonoBehaviour
{
    [SerializeField]
    private BatCapsuleFollower _batCapsuleFollowerPrefab;

    private void SpawnBatCapuleFollower()
    {
        var follower = Instantiate(_batCapsuleFollowerPrefab);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void start()
    {
        SpawnBatCapuleFollower();
    }
}
