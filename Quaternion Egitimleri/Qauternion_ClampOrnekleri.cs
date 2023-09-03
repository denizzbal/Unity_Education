//https://github.com/denizzbal
//Quaternion Clamp �rnekleri ve Klavye, Mouse Giri�i �rnekleri

using UnityEngine;

public class Qauternion_ClampOrnekleri : MonoBehaviour
{
    
    void Update()
    {
        // 1. �rnekte tranform.Rotate kullanarak y ekseninde objemizi d�nd�r�yoruz. -100 ile 100 aras�nda objemizin y eksenini s�n�rl�yoruz.
        Example1();

        // 2. �rnekte quaternion.euler kullanarak objemizin y eksenine bir de�er veriyoruz ve bu de�eri transform.rotation'a her frame'da �al��mas� i�in *= ile at�yoruz. 
        //Not: Quaternionlarda += yerine *= kullan�l�r.
        //Example2();

        // 3. �rnekte klavyemizin yatay input tu�lar�n� kullanarak, klavyemizden d�n��� biz kontrol ediyoruz. D�n��� y ekseninde -30 ile 30 aras�nda s�n�rlad�k.
        //Example3();

        // 4. �rnekte faremizin X y�n�n� (yani faremizin sola sa�a gitmesi) ald�k ve d�n���m�ze verdik. Faremizi sola hareket etirince objemiz sola, sa�a hareket ettirince objemiz sa�a gidecek.
        // Yine burada objemizin y eksenindeki d�n���n� -15 ile 15 aras�nda s�n�rlad�k.
        //Example4();
    }


    void Example1()
    {
        //Rotate kullanarak y ekseninde bir d�n�� olu�turuyoruz. De�erimizi - ile �arp�p, rotasyonumuzun y ekseninin eksiye gitmesini sa�l�yoruz.
        transform.Rotate(0, -25f * Time.deltaTime, 0);
        float yClamp;
        if(transform.eulerAngles.y <= 180)
            //Math.Clamp kullanarak  -100f ile 100f aras�nda s�n�rlad�k. Siz bu de�erleri bir de�i�kende tutun.
            yClamp = Mathf.Clamp(transform.eulerAngles.y, -100f, 100f);
        else
            yClamp = Mathf.Clamp(-(360 - transform.eulerAngles.y), -100f, 100f);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yClamp, transform.eulerAngles.z);
    }

    void Example2()
    {
        transform.rotation *= Quaternion.Euler(0, -25f * Time.deltaTime, 0);
        float yClamp;

        if(transform.eulerAngles.y <= 180)
            yClamp = Mathf.Clamp(transform.eulerAngles.y, -50, 50f);
        else
            yClamp = Mathf.Clamp(-(360 - transform.eulerAngles.y), -50, 50f);

        transform.rotation = Quaternion.AngleAxis(yClamp, Vector3.up);

    }

    void Example3()
    {
        float yKlavye = Input.GetAxis("Horizontal");
        //Vector3.up d�nece�i eksendir. Yani biz d�n��� y y�n�nde de�il de z y�n�nde yapsayd�k Vector3.forward yazard�k.
        transform.rotation *=  Quaternion.AngleAxis(yKlavye * 35f * Time.deltaTime, Vector3.up);

        //Clamp K�sa Yaz�m�
        float _clamp = Mathf.Clamp((transform.eulerAngles.y <= 180) ? transform.eulerAngles.y : -(360 - transform.eulerAngles.y), -30f, 30f);

        // Clamp Uzun Yaz�m�  - Start 
        // Yukar�da Mathf.Clamp kodlar�n�n uzun halidir. Yeni ba�layan arkada�lar yukar�da ki kodlar� anlams�z bulabilir. Onun i�in uzun halini de yaz�yorum.
        /*
        float _clamp;
        if(transform.eulerAngles.y <= 180)
            _clamp = Mathf.Clamp(transform.eulerAngles.y, -30f, 30f);
        else
            _clamp = Mathf.Clamp(-(360 - transform.eulerAngles.y), -30f, 30f);
        */

        // Clamp Uzun Yaz�m�  - End
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,_clamp, transform.eulerAngles.z);

    }

    void Example4()
    {
        //Mouse Kontroll� Rotasyon �rne�i ve Clamp

        float _mouseInput = Input.GetAxis("Mouse X");
        transform.rotation *= Quaternion.AngleAxis(_mouseInput * 45f * Time.deltaTime, Vector3.up);
        float yClamp;
        if (transform.eulerAngles.y <= 180)
            yClamp = Mathf.Clamp(transform.eulerAngles.y, -15f, 15f);
        else
            yClamp = Mathf.Clamp(-(360 - transform.eulerAngles.y), -15f, 15f);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yClamp, transform.eulerAngles.z);

    }
}
