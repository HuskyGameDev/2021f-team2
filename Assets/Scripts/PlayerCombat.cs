using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatr : MonoBehaviour
{

    public Transform attackPosition;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    // Start is called before the first frame update

     
    // Update is called once per frame
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            Attack();
        }
    }

    void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We Hit Enemy");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

}
