using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerpref : MonoBehaviour
{
    void Start()
    {
        DeleteAllPlayerPrefs();
    }
    public void DeleteAllPlayerPrefs()
    {
        
        PlayerPrefs.DeleteAll();
        Debug.Log("Xóa tất cả PlayerPrefs");
    }
}
