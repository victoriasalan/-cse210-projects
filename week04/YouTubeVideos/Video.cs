using System;
using System.Collections.Generic;

public class Video
{
    public string _title { get; }
    public string _author { get; }
    public int _videoLength { get; }

    private List<Comment> _comments;

    public Video(string title, string author, int videoLength)
    {

        _title = title;
        _author = author;
        _videoLength = videoLength;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);

    }

    public int GetNumberOfComments()
    {
        return _comments.Count;

    }

    public List<Comment> GetComments()
    {
        return _comments;

    }

}