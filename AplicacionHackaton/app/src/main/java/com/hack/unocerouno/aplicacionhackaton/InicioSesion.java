package com.hack.unocerouno.aplicacionhackaton;

import android.app.ActionBar;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import java.util.ArrayList;


import java.util.List;


/**
 * Created by Marcelo on 11/10/2014.
 */
public class InicioSesion extends Activity {






    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.iniciosesion);
        View decorView = getWindow().getDecorView();
// Hide the status bar.
        int uiOptions = View.SYSTEM_UI_FLAG_FULLSCREEN;
        decorView.setSystemUiVisibility(uiOptions);





    }

    /*public boolean onCreateOptionsMenu(Menu menu)
    {
        getMenuInflater().inflate(R.menu.inicio_sesion, menu);
        return true;
    }*/

    public void RecuperaContraseña (View view){
        Intent i = new Intent(this, RecuperarContra.class);
        startActivity(i);
    }

    public void Registra(View view) {
        Intent i = new Intent(this, Notificaciones.class);
        startActivity(i);
        finish();

    }

}
