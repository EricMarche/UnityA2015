using UnityEngine;
using System.Collections;
using UltraReal.Utilities;

public class CurserControl : Singleton {

    [SerializeField]
    CursorLockMode _lockMode = CursorLockMode.None;

    [SerializeField]
    bool _cursorVisible = true;

	// Use this for initialization
	public void Update()
    {
        Cursor.lockState = _lockMode;
        Cursor.visible = _cursorVisible;
	}
}
