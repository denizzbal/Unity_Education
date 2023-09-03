//https://github.com/denizzbal
//Quaternion Clamp Örnekleri ve Klavye, Mouse Giriþi Örnekleri

using UnityEngine;

public class Qauternion_ClampOrnekleri : MonoBehaviour
{
    
    void Update()
    {
        // 1. örnekte tranform.Rotate kullanarak y ekseninde objemizi döndürüyoruz. -100 ile 100 arasýnda objemizin y eksenini sýnýrlýyoruz.
        Example1();

        // 2. örnekte quaternion.euler kullanarak objemizin y eksenine bir deðer veriyoruz ve bu deðeri transform.rotation'a her frame'da çalýþmasý için *= ile atýyoruz. 
        //Not: Quaternionlarda += yerine *= kullanýlýr.
        //Example2();

        // 3. örnekte klavyemizin yatay input tuþlarýný kullanarak, klavyemizden dönüþü biz kontrol ediyoruz. Dönüþü y ekseninde -30 ile 30 arasýnda sýnýrladýk.
        //Example3();

        // 4. örnekte faremizin X yönünü (yani faremizin sola saða gitmesi) aldýk ve dönüþümüze verdik. Faremizi sola hareket etirince objemiz sola, saða hareket ettirince objemiz saða gidecek.
        // Yine burada objemizin y eksenindeki dönüþünü -15 ile 15 arasýnda sýnýrladýk.
        //Example4();
    }


    void Example1()
    {
        //Rotate kullanarak y ekseninde bir dönüþ oluþturuyoruz. Deðerimizi - ile çarpýp, rotasyonumuzun y ekseninin eksiye gitmesini saðlýyoruz.
        transform.Rotate(0, -25f * Time.deltaTime, 0);
        float yClamp;
        if(transform.eulerAngles.y <= 180)
            //Math.Clamp kullanarak  -100f ile 100f arasýnda sýnýrladýk. Siz bu deðerleri bir deðiþkende tutun.
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
        //Vector3.up döneceði eksendir. Yani biz dönüþü y yönünde deðil de z yönünde yapsaydýk Vector3.forward yazardýk.
        transform.rotation *=  Quaternion.AngleAxis(yKlavye * 35f * Time.deltaTime, Vector3.up);

        //Clamp Kýsa Yazýmý
        float _clamp = Mathf.Clamp((transform.eulerAngles.y <= 180) ? transform.eulerAngles.y : -(360 - transform.eulerAngles.y), -30f, 30f);

        // Clamp Uzun Yazýmý  - Start 
        // Yukarýda Mathf.Clamp kodlarýnýn uzun halidir. Yeni baþlayan arkadaþlar yukarýda ki kodlarý anlamsýz bulabilir. Onun için uzun halini de yazýyorum.
        /*
        float _clamp;
        if(transform.eulerAngles.y <= 180)
            _clamp = Mathf.Clamp(transform.eulerAngles.y, -30f, 30f);
        else
            _clamp = Mathf.Clamp(-(360 - transform.eulerAngles.y), -30f, 30f);
        */

        // Clamp Uzun Yazýmý  - End
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,_clamp, transform.eulerAngles.z);

    }

    void Example4()
    {
        //Mouse Kontrollü Rotasyon Örneði ve Clamp

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
