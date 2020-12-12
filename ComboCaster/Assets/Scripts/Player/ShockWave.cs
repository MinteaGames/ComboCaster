using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    private ParticleSystem ps;

    public static float damage = 1;
    public float knockBackDistance = 1f;

    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;
    // Start is called before the first frame update
    void Start()
    {

        damage = damage * StatMenu.inteM;

        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale += scaleChange;
        if (ps.isStopped)
        {
            Destroy(this.gameObject);        
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);


        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyProjectile")
        {
            Debug.Log("enemy hit");
            other.transform.SendMessage("TakeDamage", damage, messageOptions);

            other.transform.SendMessage("KnockBack", knockBackDistance, messageOptions);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ComboManager>().increaseComboByAmount(2);
            //Destroy(gameObject);
        }

        

    }
}
