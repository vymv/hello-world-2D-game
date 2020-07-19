using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class CharacterData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float JumpForce = 300;
    [SerializeField]
    private float MoveSpeed = 20;
    [SerializeField]
    private Transform foot;
    [SerializeField]
    private float Radius = 0.05F;
    [SerializeField]
    private Camera m_camera;
    private Transform m_trans;
    private float move = 0;
    private bool isGrounded = false;
    private Rigidbody2D m_rigid;
    private Animator m_animator;
    private float m_cameraWidth;
    private float m_limitx;
    private Collider2D m_collider2D;
   
    void Start()
    {
        m_rigid = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_collider2D = GetComponent<Collider2D>();
        //m_animator.SetBool("Jump",false);
        //m_animator.SetFloat("MoveSpeed", 9);
        if (foot == null)
        {
            //foot = GameObject.Find("Character/foot");
            foot = this.transform.Find("foot");

        }
        m_trans = this.transform;
        if(m_camera==null)
        {
            m_camera = Camera.main;
        }
        m_cameraWidth = m_camera.orthographicSize * m_camera.aspect-m_collider2D.bounds.size.x*0.5F;
    }
    void LimitX()
    {
        m_limitx = m_camera.transform.position.x - m_cameraWidth;

    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(foot.transform.position, Radius);
        if (colliders != null)
        {
            isGrounded = false;
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.Equals(this.gameObject))
                {
                    //Debug.Log("foot检测到自身");
                    Debug.Log(colliders.Length.ToString());
                    
                    //Debug.Log("isgrounded:false");

                    continue;//不着地 jump=true
                }
                else
                {
                    isGrounded = true;
                    //Debug.Log("isgrounded:true");
                    m_animator.SetBool("Jump", !isGrounded);
                    Debug.Log("foot检测到地面");
                    //Debug.Log(colliders.Length.ToString());
                    //Debug.Log(colliders[i].attachedRigidbody.name);
                }
            }

        }
        m_animator.SetFloat("YSpeed", m_rigid.velocity.y);
        
    }
    public void Move(bool jump,float horizontalInput)
    {
        if(jump&&isGrounded )
        {
            m_rigid.AddForce(new Vector2(0, JumpForce));
            m_animator.SetBool("Jump", true);
            isGrounded = false;
            Debug.Log("起跳");
        }
        else if(!isGrounded)
        {
            Debug.Log("102 isGrounded:false");//isGrounded是由foot检测到的collider决定的，就是前面的fixedupdate()
        }
        if (!jump)
        {
            Debug.Log("106 jump:false");//jump是false导致无法起跳，如果getkeydown了，jump就应该是true
        }
        move = horizontalInput * MoveSpeed;
        if (move > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (move < 0)
        {
            this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        LimitX();
        if(m_rigid.transform.position.x<=m_limitx&&move<0)
        {
            m_rigid.velocity = new Vector2(0, m_rigid.velocity.y);
        }
        else
        {
            m_rigid.velocity = new Vector2(move, m_rigid.velocity.y);
        }
        m_rigid.velocity = new Vector2(move, m_rigid.velocity.y);
        m_animator.SetFloat("MoveSpeed", Mathf.Abs(move));
    }
}
