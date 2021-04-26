using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localValue : MonoBehaviour
{
    public bool isGlobal = false;
    public Dictionary<string, float> Values = new Dictionary<string, float>();
    public Dictionary<string, string> Hashes = new Dictionary<string, string>();

    private void Start()
    {
        if (isGlobal)
        {
            if (Global.ins == null)
            {
                Global.ins = this.gameObject.GetComponent<localValue>();
                GlobalValues.init();
            }
        }
    }
    private void Update()
    {
    }
    public void Add(string key, float value)
    {
        float saved_value;
        if (Values.TryGetValue(key, out saved_value))
        {
            if (Hash.Equals(saved_value, Hashes[key]))
            {
                value = saved_value + value;
                Values[key] = value;
                Hashes[key] = Hash.get(value);
            }
            else
            {
                Values[key] = 0;
                Hashes[key] = Hash.get(0);
            }
        }
        else
        {
            Values.Add(key, value);
            Hashes.Add(key, Hash.get(value));
        }
    }
    public void Set(string key, float value)
    {
        float saved_value;
        if (Values.TryGetValue(key, out saved_value))
        {
            if (Hash.Equals(saved_value, Hashes[key]))
            {
                Values[key] = value;
                Hashes[key] = Hash.get(value);
            }
            else
            {
                Values[key] = 0;
                Hashes[key] = Hash.get(0);
            }
        }
        else
        {
            Values.Add(key, value);
            Hashes.Add(key, Hash.get(value));
        }
    }
    public float Get(string key)
    {
        float saved_value;
        if (Values.TryGetValue(key, out saved_value))
        {
            float saved_hash = Values[key];
            if (Hash.Equals(saved_hash, Hash.get(saved_value)))
            {
                return saved_value;
            }
            else
            {
                Values[key] = 0;
                Hashes[key] = Hash.get(0);
                return 0;
            }

        }
        else
        {
            return 0;
        }
    }
}
