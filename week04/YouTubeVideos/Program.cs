using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("10 Steps for fitlife", "FitLife", 600);
        Video video2 = new Video("Learn python in One Hour", "CodeMaster", 3600);
        Video video3 = new Video(" Ancient Mozambique", "WorldTravelers", 1800);

        // Add comments to video 1
        video1.AddComment(new Comment("Joan", "Great Technic!"));
        video1.AddComment(new Comment("Johanes", "Short but effective."));
        video1.AddComment(new Comment("Tamara", "Loved this routine!"));

        // Add comments to video 2
        video2.AddComment(new Comment("Clif", " clear coding technic."));
        video2.AddComment(new Comment("Mary", "Drop some more tutorials!"));
        video2.AddComment(new Comment("Lydia", "Kindly expplain about functions."));

        // Add comments to video 3
        video3.AddComment(new Comment("Emmanuel", "That is wellcoming footage."));
        video3.AddComment(new Comment("Bashir", "I want to visit someday."));
        video3.AddComment(new Comment("Wani", "Home is the best!"));

        // Add videos to list
        List<Video> videos = new List<Video>() { video1, video2, video3 };
        

        // Display info for each video
        foreach (Video v in videos)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Title:  {v.Title}");
            Console.WriteLine($"Author: {v.Author}");
            Console.WriteLine($"Length: {v.LengthSeconds} seconds");
            Console.WriteLine($"Comments ({v.GetCommentCount()}):");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($"  - {c.CommenterName}: {c.CommentText}");
            }

            Console.WriteLine(); // space between videos
        }
    }
}
