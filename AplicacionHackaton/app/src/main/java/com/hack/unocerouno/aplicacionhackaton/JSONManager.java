package com.hack.unocerouno.aplicacionhackaton;

/**
 * Created by Marcelo on 11/10/2014.
 */
import android.app.Activity;
import android.widget.Button;
import android.widget.ListView;

import org.json.JSONObject;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;



public class JSONManager extends Activity {

    private static final String NAMESPACE = "http://tempuri.org/";
    private static String URL="android920228/webcindario.com/service.quejas.php";
    private static final String METHOD_NAME = "getAllAndroidOS";
    private static final String SOAP_ACTION ="http://tempuri.org/getAllAndroidOS";

    //Declaracion de variables para consuymir el web service
    private SoapObject request=null;
    private SoapSerializationEnvelope envelope=null;
    private SoapPrimitive  resultsRequestSOAP=null;

    //Declaracion de variables para serealziar y deserealizar
    //objetos y cadenas JSON
    JSONObject gson ;

    //Variables para manipular los controles de la UI
    Button btn;
    ListView lsvAndroidOS;

    /** Called when the activity is first created. */



}
