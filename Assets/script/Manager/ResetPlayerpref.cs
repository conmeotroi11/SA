using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerpref : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DeleteAllPlayerPrefs();
    }

    // Update is called once per frame
    public void DeleteAllPlayerPrefs()
    {
        // Xóa tất cả PlayerPrefs
        PlayerPrefs.DeleteAll();
        Debug.Log("Xóa tất cả PlayerPrefs");
    }
}
