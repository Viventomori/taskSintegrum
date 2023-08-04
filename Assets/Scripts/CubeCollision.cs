using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CubeCollision : MonoBehaviour
{
    [Tooltip("Move your count text here")]
    [SerializeField]
    private Text textCount; 
    private int collisionCount = 0; // Лічильник зіткнень

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false); 
            collisionCount++;
            textCount.text = "Count " + collisionCount;

            MeshRenderer cubeRenderer = GetComponent<MeshRenderer>();
            cubeRenderer.material.color = Random.ColorHSV();

            StartCoroutine(ScaleAnimation());
        }
    }

    private IEnumerator ScaleAnimation()
    {
       
        float time = 0f;
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);
        while (time < 1f)
        {
            time += Time.deltaTime * 2f; 
            transform.localScale = Vector3.Lerp(initialScale, targetScale, time);
            yield return null;
        }


        time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * 2f; 
            transform.localScale = Vector3.Lerp(targetScale, initialScale, time);
            yield return null;
        }
    }
}