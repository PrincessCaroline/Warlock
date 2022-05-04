using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class ReceiveDamage : NetworkBehaviour
{
    [SerializeField]
    private float maxHealth = 10f;

    [SyncVar]
    private float currentHealth;

    [SerializeField]
    private string spellTag;

    [SerializeField]
    private Image LifeLeft;

    // Use this for initialization
    void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("COllision !");
        // force is how forcefully we will push the player away from the enemy.
        float force = 3;

        // If the object we hit is the enemy
        if (c.gameObject.tag == this.spellTag &&
            this.GetComponent<WarlockController>().id != c.gameObject.GetComponent<SpellModel>().id)
        {

            TakeDamage(1);
            Destroy(c.collider.gameObject);

            // Calculate Angle Between the collision point and the player
            Vector3 dir = c.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }

    void TakeDamage(int amount)
    {
        if (this.isServer)
        {
            this.currentHealth -= amount;
            LifeLeft.fillAmount = (float)(this.currentHealth * this.maxHealth / 100f);
            if (this.currentHealth <= 0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}