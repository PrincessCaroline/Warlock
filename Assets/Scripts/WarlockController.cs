using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WarlockController : NetworkBehaviour
{
    public Guid id;

    // Start is called before the first frame update
    void Start()
    {
        if (this.isLocalPlayer)
        {
            id = Guid.NewGuid();
            Camera.main.GetComponent<CameraFollow>().SetPlayer(this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move player
        if (this.isLocalPlayer)
        {
            if (!this.GetComponent<CastSpell>().onCast)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 clicPosition = Tools.GetMousePosition();

                    SetDestination(clicPosition);
                }
            }
        }
    }

    public void SetDestination(Vector3 destination)
    {
        try
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
