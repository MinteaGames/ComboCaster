﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    private ParticleSystem ps;

    public float damage = 1;
    public float knockBackDistance = 1f;

    SendMessageOptions messageOptions = SendMessageOptions.DontRequireReceiver;
    // Start is called before the first frame update
    void Start()
    {
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

    private void OnCollisionEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Enemy")
        {
            Debug.Log("enemy hit");
            other.transform.SendMessage("TakeDamage", damage, messageOptions);

            other.transform.SendMessage("KnockBack", knockBackDistance, messageOptions);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ComboManager>().increaseComboByAmount(2);
            //Destroy(gameObject);
        }
    }
}
