using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;

public static class Hash
{
    static SHA256 sha256 = null;
    static Hash()
    {
        if (sha256 == null)
        {
            sha256 = new SHA256Managed();
        }
    }
    public static bool Equals(object _plain, string _hash)
    {
        string plainString = _plain.ToString();

        byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainString));
        return (_hash == Convert.ToBase64String(hash));
    }
    public static string get(object _plain)
    {
        string plainString = _plain.ToString();

        byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainString));
        return Convert.ToBase64String(hash);
    }
}
