using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Discovering the worlds biggest caves", "TeoTheExplorer", 950);
        video1.AddComment(new Comment("Gabriel", "Amazing Video Bro!"));
        video1.AddComment(new Comment("Bryan", "The third one was my favorite!"));
        video1.AddComment(new Comment("Valentina", "Those caves look so dark, scary."));
        videos.Add(video1);

        Video video2 = new Video("Making banana bread!", "BriannaCocina", 843);
        video2.AddComment(new Comment("Andrea", "I love Banana bread!"));
        video2.AddComment(new Comment("Kevin", "My mom loves this recipe, thank you for the video!"));
        video2.AddComment(new Comment("Celeste", "Thank you! I'll be making this for my sister's party."));
        videos.Add(video2);

        Video video3 = new Video("Gameplay: Exploring Roblox world", "gamerpro31", 523);
        video3.AddComment(new Comment("John", "That's my favorite game!"));
        video3.AddComment(new Comment("Karla", "My little brother loves this game."));
        video3.AddComment(new Comment("Daniel", "I've been trying to get to that world but can't pass the last level"));
        videos.Add(video3);


        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length in seconds: {video._videoLength}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" {comment._nameOfCommenter}: {comment._textOfComment}");
            }
            Console.WriteLine(new string('-', 40));

        }

    }
}