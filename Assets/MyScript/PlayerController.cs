using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    int count;
    public Text countText;
    AudioSource getSE;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        getSE = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveH, 0, moveV);
        rb.AddForce(move * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            getSE.Play();
            count += 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Bottom"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void SetCountText()
    {
        countText.text = "ゲット数： " + count.ToString();
    }

}
