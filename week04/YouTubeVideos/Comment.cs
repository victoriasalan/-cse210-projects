using System;

public class Comment
{
    public string _nameOfCommenter { get; }
    public string _textOfComment { get; }

    public Comment(string nameOfCommenter, string textOfComment)
    {
        _nameOfCommenter = nameOfCommenter;
        _textOfComment = textOfComment;
    }
}