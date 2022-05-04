using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            this.transform.position = _player.position + new Vector3(0, 10, -10);
        }
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }
}
