using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CastSpell : NetworkBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

    private LineRenderer _targetLine;
    public bool onCast;

    private void Start()
    {
        _targetLine = this.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            onCast = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            onCast = false;
        }


        if (this.isLocalPlayer && onCast)
        {
            Vector3 worldPosition = Tools.GetMousePosition();
            Vector3 straightDirection = new Vector3(worldPosition.x, this.transform.position.y, worldPosition.z);

            _targetLine.SetPositions(new[] { this.transform.position, straightDirection});
            _targetLine.startWidth = 0.5f;
            _targetLine.endWidth = 0.5f;
            if (Input.GetMouseButtonDown(0))
            {
                this.Cast(straightDirection);
                onCast = false;
            }
        }
        else
        { 
            // Reset target
            _targetLine.SetPositions(new[] { Vector3.zero, Vector3.zero});
        }
    }


    [Command]
    void Cast(Vector3 worldPosition)
    {
        GameObject fireBall = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

        fireBall.GetComponent<SpellModel>().id = this.GetComponent<WarlockController>().id;
        fireBall.GetComponent<Rigidbody>().velocity = (worldPosition - this.transform.position).normalized * bulletSpeed;

        NetworkServer.Spawn(fireBall);
        Destroy(fireBall, 5f); // To do : Dynamic lifetime
    }
}