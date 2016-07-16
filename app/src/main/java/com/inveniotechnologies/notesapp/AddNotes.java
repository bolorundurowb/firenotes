package com.inveniotechnologies.notesapp;

import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.EditText;
import android.widget.ProgressBar;
import com.firebase.client.Firebase;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

public class AddNotes extends AppCompatActivity {

    public static final String PREFS_NAME = "UsernameFile";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //
        Firebase.setAndroidContext(this);
        //
        setContentView(R.layout.activity_add_notes);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab_save);
        if (fab != null) {
            fab.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    ProgressBar prg_saving = (ProgressBar) findViewById(R.id.prg_saving);
                    EditText txt_note_title = (EditText) findViewById(R.id.txt_note_title);
                    EditText txt_note_details = (EditText) findViewById(R.id.txt_note_details);
                    //
                    String title = txt_note_title.getText().toString();
                    if (title.matches("")) {
                        AlertDialog.Builder builder = new AlertDialog.Builder(AddNotes.this);
                        builder.setMessage("You have not entered a Fire Note title").setCancelable(false).setPositiveButton("OK", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                //
                            }
                        });
                        AlertDialog ad = builder.create();
                        ad.setTitle("Incomplete Info");
                        ad.show();
                    } else {
                        prg_saving.setIndeterminate(true);
                        prg_saving.setVisibility(View.VISIBLE);
                        txt_note_details.setEnabled(false);
                        txt_note_title.setEnabled(false);
                        //
                        final Note note = new Note();
                        note.setDetails(txt_note_details.getText().toString());
                        note.setTitle(txt_note_title.getText().toString());
                        note.setSavedAt(new Date());
                        //
                        new Thread(new Runnable() {
                            @Override
                            public void run() {
                                Firebase myFirebaseRef = new Firebase("https://androfirenotes.firebaseio.com/");
                                Firebase usersRef = myFirebaseRef.child("users");
                                //
                                SharedPreferences settings = getSharedPreferences(PREFS_NAME, 0);
                                String username = settings.getString("Username","");
                                //
                                Firebase userRef = usersRef.child(username);
                                Map<String, Object> data = new HashMap<String, Object>();
                                data.put("title",note.getTitle());
                                data.put("details",note.getDetails());
                                data.put("date",note.getSavedAt().toString());
                                userRef.updateChildren(data);
//
                                finish();
                            }
                        }).start();
                    }
                }
            });
        }
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

}
