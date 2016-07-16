package com.inveniotechnologies.notesapp;

import com.google.firebase.database.Exclude;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

/**
 * Created by bolorundurowb on 05-Jul-16.
 */
public class Note {
    private String Title;
    private String Details;
    private Date SavedAt;

    public String getTitle() {
        return Title;
    }

    public void setTitle(String title) {
        Title = title;
    }

    public String getDetails() {
        return Details;
    }

    public void setDetails(String details) {
        Details = details;
    }

    public Date getSavedAt() {
        return SavedAt;
    }

    public void setSavedAt(Date savedAt) {
        SavedAt = savedAt;
    }
    //
    public Note(){

    }

    public Note(String title, String details, String date) {
        this.setTitle(title);
        this.setDetails(details);
        SimpleDateFormat sdf = new SimpleDateFormat("EEE MMM dd yyyy HH:mm:ss zzz");
        try {
            this.setSavedAt(sdf.parse(date));
        }
        catch (ParseException | NullPointerException e){
            this.setSavedAt(new Date());
        }
    }
    //
    @Exclude
    public Map<String, Object> toMap() {
        HashMap<String, Object> result = new HashMap<>();
        result.put("title", getTitle());
        result.put("details", getDetails());
        result.put("savedAt", getSavedAt().toString());

        return result;
    }
}
