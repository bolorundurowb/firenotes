package com.inveniotechnologies.notesapp;

import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class Settings extends AppCompatActivity {

    public static final String PREFS_NAME = "UsernameFile";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        //
        EditText txt_username = (EditText) findViewById(R.id.txt_username);
        //
        SharedPreferences settings = getSharedPreferences(PREFS_NAME, 0);
        final String username = settings.getString("Username","");
        //
        txt_username.setText(username);
        //
        Button btn_update = (Button) findViewById(R.id.btn_update);
        if (btn_update != null) {
            btn_update.setOnClickListener(new View.OnClickListener(){
                @Override
                public void onClick(View v){

                }
            });
        }
        //
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

}
