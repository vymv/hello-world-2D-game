using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterData))]
public class CharacterControl : MonoBehaviour
{
    // Start is called before the first frame update
    private bool m_jump = false;
    private float horizontalInput;
    private CharacterData m_data;
    void Start()
    {
        m_data = GetComponent<CharacterData>();

    }
    public void StopControl()
    {
        this.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        m_jump = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_jump = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");

    }
    void FixedUpdate()
    {
        m_data.Move(m_jump, horizontalInput);
    }

}
