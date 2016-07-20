package com.inveniotechnologies.notesapp;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.EditText;

public class EditNote extends AppCompatActivity {
    private EditText txt_title;
    private EditText txt_details;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit_note);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        //
        txt_details = (EditText) findViewById(R.id.txt_note_details) ;
        txt_title = (EditText) findViewById(R.id.txt_note_title);
        //
        Intent intent = getIntent();
        final Note note = (Note) intent.getSerializableExtra("Note");
        //
        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab_save);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //
        txt_title.setText(note.getTitle());
        txt_details.setText(note.getDetails());
    }

}
