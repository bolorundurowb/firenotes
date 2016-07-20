package com.inveniotechnologies.notesapp;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.widget.TextView;

public class Settings extends AppCompatActivity {

    public static final String PREFS_NAME = "UsernameFile";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        //
        TextView lbl_username = (TextView) findViewById(R.id.lbl_username);
        //
        SharedPreferences settings = getSharedPreferences(PREFS_NAME, 0);
        final String username = settings.getString("Username","");
        //
        lbl_username.setText(username);
        //
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

}
