using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (karakter)

    public float smoothSpeed = 0.125f; // Kamera takip yumuşatma hızı
    public Vector3 offset; // Kamera ile hedef arasındaki başlangıç mesafesi

    private void LateUpdate()
    {
        // Hedefin pozisyonunu alırken yükseklik değerini korumak için Z eksenini değiştiriyoruz
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y + 2, transform.position.z) + offset;

        // Yumuşak bir geçişle kamerayı hedef pozisyona taşıyoruz
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
