package com.hack.unocerouno.aplicacionhackaton;

import android.app.ActionBar;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;

/**
 * Created by Marcelo on 10/10/2014.
 */
public class Reportes extends Activity{


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.reportes);
        View decorView = getWindow().getDecorView();
// Hide the status bar.
        int uiOptions = View.SYSTEM_UI_FLAG_FULLSCREEN;
        decorView.setSystemUiVisibility(uiOptions);
// Remember that you should never show the action bar if the
// status bar is hidden, so hide that too if necessary.


    }

public void NotificarReporte (){
    Intent i = new Intent(this, NotifyReporte.class);
    startActivity(i
    );
}

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.inicio_sesion, menu);
        return true;
    }


    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        switch (item.getItemId()) {
            case R.id.action_notificaciones:
                Intent i = new Intent(this, Notificaciones.class);
                startActivity(i);
                return true;
            case R.id.action_reportar:
                Intent j = new Intent(this, Reportes.class);
                startActivity(j);
                finish();
                return true;
            case R.id.action_ubicacion:
                Intent k = new Intent(this, Ubicacion.class);
                startActivity(k);
                return true;
            case R.id.action_cerrarsesion:
                Intent l = new Intent(this, InicioSesion.class);
                startActivity(l);
                finish();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

}
