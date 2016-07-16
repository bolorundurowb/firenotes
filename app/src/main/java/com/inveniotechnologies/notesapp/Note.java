package com.inveniotechnologies.notesapp;

import java.util.Date;

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
}
