using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{

    protected List<Transform> targets = new List<Transform>();

    [SerializeField]
    protected string name;
    [SerializeField]
    protected float shootDelay;
    [SerializeField]
    protected float damage;

    // Update is called once per frame
    protected bool LookAtTarget()
    {
        if(targets.Count > 0)
        {
            Vector3 pos = targets[0].position;

            Vector3 dir = (pos - transform.position).normalized;

            transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.y,dir.x));
            return true;
        }
        return false;
    }

    protected void shoot()
    {
        if(targets.Count > 0)
            targets[0].GetComponent<EnemyBase>().health -= damage;
        GetComponent<ParticleSystem>().Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            targets.Add(collision.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            targets.Remove(collision.gameObject.transform);
        }
    }
}
