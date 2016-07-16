package com.inveniotechnologies.notesapp;

import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.firebase.client.ChildEventListener;
import com.firebase.client.DataSnapshot;
import com.firebase.client.Firebase;
import com.firebase.client.FirebaseError;
import com.firebase.client.Query;

public class Settings extends AppCompatActivity {

    public static final String PREFS_NAME = "UsernameFile";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //
        Firebase.setAndroidContext(this);
        //
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
                    Firebase usersRef = new Firebase("https://androfirenotes.firebaseio.com/users");
                    //
                    Query query = usersRef.orderByKey();
                    query.addChildEventListener(new ChildEventListener() {
                        boolean exists = false;

                        @Override
                        public void onChildAdded(DataSnapshot dataSnapshot, String s) {
                            if(dataSnapshot.getKey() == username) {
                                exists = true;
                            }
                            if(exists){
                                AlertDialog.Builder builder = new AlertDialog.Builder(Settings.this);
                                builder.setMessage("The entered username exists. Please enter another one").setCancelable(false).setPositiveButton("OK", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int which) {
                                        //
                                    }
                                });
                                AlertDialog ad = builder.create();
                                ad.setTitle("");
                                ad.show();
                            } else {
                                System.out.println("Not found");
                            }

                        }

                        @Override
                        public void onChildChanged(DataSnapshot dataSnapshot, String s) {

                        }

                        @Override
                        public void onChildRemoved(DataSnapshot dataSnapshot) {

                        }

                        @Override
                        public void onChildMoved(DataSnapshot dataSnapshot, String s) {

                        }

                        @Override
                        public void onCancelled(FirebaseError firebaseError) {

                        }
                    });
                }
            });
        }
        //
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

}
