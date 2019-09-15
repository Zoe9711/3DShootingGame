using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    #region Editor Variables
    //[SerializeField]
    //[Tooltip("how fast the chicken moves randomly")]
    //private float m_Speed;

    [SerializeField]
    [Tooltip("amount of damage on collision")]
    private float m_Damage;

    [SerializeField]
    [Tooltip("how much health this chicken has")]
    private int m_MaxHealth;

    [SerializeField]
    [Tooltip("how fast the chicken can move")]
    private float m_Speed;

    [SerializeField]
    [Tooltip("it drops grass")]
    private GameObject m_Grass;

    #endregion

    #region Private Variables
    private float p_curHealth;


    #endregion

    #region Cached Components
    private Rigidbody cc_Rb;

    #endregion


    #region Cached References
    private Transform cr_Player;

    #endregion

    #region Initialization

    private void Awake()
    {
        p_curHealth = m_MaxHealth;
        cc_Rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        //cr_Player = FindObjectOfType<PlayerController>().transform;

        StartCoroutine(randomMove());

    }

    #endregion


    #region Main Updates

    //private void FixedUpdate()
    //{
    //    Vector3 dir = cr_Player.position - transform.position;
    //    dir.Normalize();
    //    cc_Rb.MovePosition(cc_Rb.position + dir * m_Speed * Time.fixedDeltaTime);
    //}

    private IEnumerator randomMove()
    {
        yield return new WaitForSeconds(3);
        Vector3 dir = RandomVector(0, 100);
        dir.Normalize();
        cc_Rb.MovePosition(cc_Rb.position + dir * m_Speed * Time.fixedDeltaTime);
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, 0, z);
    }

    #endregion


    #region Collision Methods
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().DecreaseHealth(m_Damage);
        }
    }

    #endregion

    #region Health Methods
    public void DecreaseHealth(float amount)
    {
        p_curHealth -= amount;
        if (p_curHealth <= 0)
        {

            
            Instantiate(m_Grass, transform.position, Quaternion.identity);
            

            Destroy(gameObject);
        }
    }

    #endregion


}

