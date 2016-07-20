package com.inveniotechnologies.notesapp;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.TextView;

public class ViewNote extends AppCompatActivity {
    private TextView lbl_title;
    private TextView lbl_details;
    private TextView lbl_saved_at;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_note);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        //
        Intent intent = getIntent();
        final Note note = (Note) intent.getSerializableExtra("Note");
        //
        lbl_details = (TextView) findViewById(R.id.lbl_note_details);
        lbl_title = (TextView) findViewById(R.id.lbl_note_title) ;
        lbl_saved_at = (TextView) findViewById(R.id.lbl_saved_at);
        //
        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab_edit);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(),EditNote.class);
                intent.putExtra("Note", note);
                startActivity(intent);
            }
        });
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        //
        lbl_title.setText(note.getTitle());
        lbl_details.setText(note.getDetails());
        lbl_saved_at.setText(note.getSavedAt().toString());
    }
}
