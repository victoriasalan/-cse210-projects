using System;
using System.Collections.Generic;

public class Video
{
    public string _title;
    public string _author;
    public int _videoLength;

    private List<Comment> _comments;

    public Video(string title, string author, int videoLength)
    {

        _title = title;
        _author = author;
        _videoLength = videoLength;
        _comments = new List<Comment>();
    }



}